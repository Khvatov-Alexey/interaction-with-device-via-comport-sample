using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Data;
using System.Runtime.Serialization;
using NLog;

namespace Serialport_communication.Model
{
    public class Device
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Имя устройства
        /// </summary>
        public static string name = "Имя устройства";

        private struct DataUI
        {
            public bool single;
            public bool run;
            public bool need_log;
            public byte[] osn, dop, main;
            public bool autoDetectInFirstStartup;
            public bool needCheckConnect;
            public SerialPort testSerialPort;
        }

        private SerialPort comport = null;
        private Form1 UI;
        /// <summary>
        /// Уникальный код устройства. Задается протоколом обмена. Используется в RS-485 для адресации сообщений
        /// </summary>
        private static byte Device_code = 0x11;
        /// <summary>
        /// Пауза между запросом и приемом данных
        /// </summary>
        private static int read_timeout = 30;

        public object dataLocker = new object();
        /// Эти поля мы получаем из UI
        private DataUI dataUI, dataUI_forStream;

        //---------------------------------------------------------------------------

        public Device(Form1 _mainform)
        {
            UI = _mainform;
            comport = new SerialPort();
            data_init();
        }
        private void data_init()
        {
            lock(dataLocker)
            {
                dataUI.single = false;
                dataUI.run = false;
                dataUI.need_log = false;
                dataUI.osn = new Byte[2] { 0x00, 0x00 };
                dataUI.dop = new Byte[2] { 0x00, 0x00 };
                dataUI.main = new Byte[2] { 0x00, 0x00 };
                dataUI.autoDetectInFirstStartup = true;
                dataUI.needCheckConnect = false;
                dataUI.testSerialPort = null;
            }
        }
        private void applyData_toStream()
        {
            lock (dataLocker)
            {
                dataUI_forStream = dataUI;
            }
        }

        //---------------------------------------------------------------------------

        #region Обертки для SerialPort
        private void reopen()
        {
            comport.Close();
            lock(dataLocker)
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.portname))
                {
                    throw new OpenOrWriteException("Номер COM-порта не указан");
                }
                comport.PortName = Properties.Settings.Default.portname;
                comport.BaudRate = Properties.Settings.Default.baudrate;
                comport.Parity = Properties.Settings.Default.parity;
                comport.DataBits = Properties.Settings.Default.dataBits;
                comport.StopBits = Properties.Settings.Default.stopBits;
            }
            comport.Handshake = Handshake.None;
            comport.ReadTimeout = 100;
            comport.WriteTimeout = 100;
            try
            {
                if (!comport.IsOpen) comport.Open();
                comport.DiscardOutBuffer();
                comport.DiscardInBuffer();
            }
            catch (System.IO.IOException)
            {
                throw new OpenOrWriteException("Ошибка открытия COM-порта (" + comport.PortName + ")");
            }
            catch (InvalidOperationException)
            {
                throw new OpenOrWriteException("COM-порт был закрыт (" + comport.PortName + ")");
            }
            catch (UnauthorizedAccessException) 
            {
                throw new OpenOrWriteException("Доступ к COM-порту закрыт (" + comport.PortName + ")");
            }
        }
        private static void write(SerialPort comport, byte[] byteBuffer)
        {
            try
            {
                comport.Write(byteBuffer, 0, byteBuffer.Length);
            }
            catch (TimeoutException)
            {
                throw new OpenOrWriteException("Ошибка при передаче");
            }
            catch (InvalidOperationException)
            {
                throw new OpenOrWriteException("COM-порт был закрыт (" + comport.PortName + ")");
            }
        }
        private static int read(SerialPort comport, byte[] byteBuffer)
        {
            int cnt = 0;
            try
            {
                cnt = comport.Read(byteBuffer, 0, byteBuffer.Length);
            }
            catch (TimeoutException)
            {
                throw new ReadException("Нет ответа");
            }
            catch (InvalidOperationException)
            {
                throw new ReadException("COM-порт был закрыт (" + comport.PortName + ")");
            }

            return cnt;
        }
        private void close()
        {
            if (comport != null) comport.Close();
        }
        #endregion

        //---------------------------------------------------------------------------

        #region Кодограммы
        private byte[] c_fdk(byte[] osn, byte[] dop, byte[] main, bool need_log)
        {
            byte[] byteBuffer = new byte[9] { 0xF0, Device_code, osn[0], osn[1], dop[0], dop[1], main[0], main[1], 0xAA };
            write(comport, byteBuffer);
            if (need_log) UI.AddLog("Write to " + comport.PortName + ": " + byteBuffer_toString(byteBuffer), System.Drawing.Color.Black);
            logger.Info($"{name}: отправили команду {System.Reflection.MethodBase.GetCurrentMethod().Name}:" +
                $"{Environment.NewLine}+50В ОСН={byteToDouble(osn[0], osn[1]):N1}" +
                $"{Environment.NewLine}+50В ДОП={byteToDouble(dop[0], dop[1]):N1}" +
                $"{Environment.NewLine}+50В={byteToDouble(main[0], main[1]):N1}");
            logger.Debug($"{name}: write to {comport.PortName}: {byteBuffer_toString(byteBuffer)}");

            Thread.Sleep(read_timeout);

            byte[] received = new byte[18];
            int cnt = read(comport, received);
            if (need_log) UI.AddLog("Read from " + comport.PortName + " (" + cnt + "): " + byteBuffer_toString(received), System.Drawing.Color.Black);
            logger.Debug($"{name}: read from {comport.PortName} ({cnt}): {byteBuffer_toString(received)}");
            if (!checkCRC7(received)) throw new ReadException("Ошибка в контрольной сумме ответа от субблока");
            logger.Info($"{name}: получили ответ на команду {System.Reflection.MethodBase.GetCurrentMethod().Name}:" +
                $"{Environment.NewLine}+50В ОСН={byteToDouble(received[2], received[3]):N1} (" + ((received[16] & 0x01) != 0 ? "error" : "ok") + ")" +
                $"{Environment.NewLine}+50В ДОП={byteToDouble(received[4], received[5]):N1} (" + ((received[16] & 0x02) != 0 ? "error" : "ok") + ")" +
                $"{Environment.NewLine}+50В={byteToDouble(received[6], received[7]):N1} (" + ((received[16] & 0x04) != 0 ? "error" : "ok") + ")" +
                $"{Environment.NewLine}+50В={byteToDouble(received[8], received[9]):N1} (" + ((received[16] & 0x08) != 0 ? "error" : "ok") + ")" +
                $"{Environment.NewLine}+50В={byteToDouble(received[10], received[11]):N1} (" + ((received[16] & 0x10) != 0 ? "error" : "ok") + ")" +
                $"{Environment.NewLine}+50В={byteToDouble(received[12], received[13]):N1} (" + ((received[16] & 0x20) != 0 ? "error" : "ok") + ")" +
                $"{Environment.NewLine}+50В={byteToDouble(received[14], received[15]):N1} (" + ((received[16] & 0x40) != 0 ? "error" : "ok") + ")");
            return received;
        }
        private static bool c_who(SerialPort comport, Action<string, System.Drawing.Color> log)
        {
            byte[] buffer = new byte[4] { 0xF1, Device_code, 0x02, 0xAA };
            write(comport, buffer);
            if (log != null) log("Write to " + comport.PortName + ": " + byteBuffer_toString(buffer), System.Drawing.Color.Black);
            logger.Debug($"{name}: write to {comport.PortName}: {byteBuffer_toString(buffer)}");

            Thread.Sleep(Device.read_timeout);

            byte[] received = new byte[4];
            int cnt = Device.read(comport, received);
            if (log != null) log("Read from " + comport.PortName + " (" + cnt + "): " + byteBuffer_toString(received), System.Drawing.Color.Black);
            logger.Debug($"{name}: Read from  {comport.PortName}: {byteBuffer_toString(received)}");
            if (!checkCRC7(received)) throw new ReadException("Ошибка в контрольной сумме ответа от устройства");
            return received[0] == 0xF1 && received[1] == Device.Device_code && received[2] == 0x01;
        }
        #endregion

        //---------------------------------------------------------------------------

        public static bool checkCRC7(byte[] buffer)
        {
            logger.Debug($"{name}: Проверка CRC7: 0x{buffer[buffer.Length - 1]:X2} == 0x{Help.CRC7.crc7(buffer, false):X2}");
            return (int)buffer[buffer.Length - 1] == Help.CRC7.crc7(buffer, false);
        }
        public static byte[] doubleToByte(double value)
        {
            byte[] result = new byte[2];
            result[0] = (byte)Math.Abs((int)value);
            result[1] = (byte)(Math.Round(value, 1) * 10 % 10);
            return result;
        }
        public static double byteToDouble(byte integer, byte fractional)
        {
            return (double)integer + ((int)fractional) / 10.0;
        }
        public static string byteBuffer_toString(byte[] _buffer)
        {
            string res = "";
            foreach (var hex in _buffer)
            {
                res += "0x" + hex.ToString("X2") + "; ";
            }
            if (!string.IsNullOrEmpty(res)) res.Remove(res.Length - 1, 1);
            return res;
        }

        //---------------------------------------------------------------------------

        #region Взаимодействие с UI
        public void setData__fromUI(bool single, bool run, bool need_log, FDK_output voltages)
        {
            lock (dataLocker)
            {
                dataUI.single = single;
                dataUI.run = run;
                dataUI.need_log = need_log;
                dataUI.osn = doubleToByte(voltages.Plus50v_osn);
                dataUI.dop = doubleToByte(voltages.Plus50v_dop);
                dataUI.main = doubleToByte(voltages.Plus50v);
            }
            logger.Trace($"Поток: приняты данные от UI");
        }
        public void setCheckConnect(string portname, int baudrate, Parity parity, int dataBits, StopBits stopBits)
        {
            lock (dataLocker)
            {
                dataUI.testSerialPort = new SerialPort(portname, baudrate, parity, dataBits, stopBits);
                dataUI.needCheckConnect = true;
            }
        }
        private void set_FDKData__toUI(ref byte[] received, bool single, bool run)
        {
            Connectivity connectivity = new Connectivity(single, run, Connectivity.Connect_status.success);
            FDK_input fdk_data = new FDK_input();
            fdk_data.plus50v_osn = new Tuple<double?, bool>(byteToDouble(received[2],  received[3]),  (received[16] & 0x01) == 1);
            fdk_data.plus50v_dop = new Tuple<double?, bool>(byteToDouble(received[4],  received[5]),  (received[16] & 0x02) == 1);
            fdk_data.plus50v     = new Tuple<double?, bool>(byteToDouble(received[6],  received[7]),  (received[16] & 0x04) == 1);
            fdk_data.plus300v    = new Tuple<double?, bool>(byteToDouble(received[8],  received[9]),  (received[16] & 0x08) == 1);
            fdk_data.plus5v      = new Tuple<double?, bool>(byteToDouble(received[10], received[11]), (received[16] & 0x10) == 1);
            fdk_data.plus12v     = new Tuple<double?, bool>(byteToDouble(received[12], received[13]), (received[16] & 0x20) == 1);
            fdk_data.minus12v    = new Tuple<double?, bool>(byteToDouble(received[14], received[15]), (received[16] & 0x40) == 1);

            UI.setParams__toUI(connectivity, fdk_data);
            logger.Trace($"Поток: отправлены данные в UI");
        }
        private void setConnectivity_toUI(Connectivity connectivity)
        {
            UI.setConnectivity_toUI(connectivity);
            logger.Trace($"Поток: переданы в UI данные о связи");
        }

        private void log(string msg, System.Drawing.Color color)
        {
            UI.AddLog($"{name}: {msg}", color);
        }
        public static bool checkConnect(string portname, int baudrate, Parity parity, int dataBits, StopBits stopBits, System.Windows.Forms.Form form)
        {
            logger.Info($"{name}: начинаем проверку соединения ({portname})");
            SerialPort port = new SerialPort(portname, baudrate, parity, dataBits, stopBits);
            port.Handshake = Handshake.None;
            port.ReadTimeout = 100;
            port.WriteTimeout = 100;
            try
            {
                bool opened = false;
                try
                {
                    if (port != null) port.Close();
                    port.Open();
                    opened = true;
                }
                catch (System.IO.IOException) { }
                catch (InvalidOperationException) { }
                catch (OpenOrWriteException) { }
                catch (ReadException) { }
                catch (UnauthorizedAccessException) { }

                if (!opened)
                {
                    if(form != null) Popup_notification.Show("Ошибка создания соединения", Popup_notification.enmType.Error, form, 12);
                    logger.Warn($"{name}: Ошибка создания соединения");
                    return false;
                }

                try
                {
                    if (c_who(port, null))
                    {
                        if (form != null) Popup_notification.Show("Соединение возможно", Popup_notification.enmType.Success, form, 12);
                        logger.Info($"{name}: Соединение возможно");
                        return true;
                    }
                }
                catch (System.IO.IOException) { }
                catch (InvalidOperationException) { }
                catch (OpenOrWriteException) { }
                catch (ReadException) { }
                catch (UnauthorizedAccessException) { }
            }
            finally
            {
                if (port != null) port.Close();
            }
            if (form != null) Popup_notification.Show("Соединение возможно", Popup_notification.enmType.Success, form, 12);
            if (form != null) Popup_notification.Show("Тестируемое устройство не определено", Popup_notification.enmType.Warning, form, 12);
            logger.Warn($"{name}: Соединение возможно{Environment.NewLine}Тестируемое устройство не определено");
            return true;
        }
        public static string findDevice(int baudrate, Parity parity, int dataBits, StopBits stopBits)
        {
            logger.Info($"{name}: Начинаем автопоиск устройства...");
            SerialPort port = new SerialPort();
            port.BaudRate = baudrate;
            port.Parity = parity;
            port.DataBits = dataBits;
            port.StopBits = stopBits;
            port.Handshake = Handshake.None;
            port.ReadTimeout = 100;
            port.WriteTimeout = 100;

            string[] portnames = SerialPort.GetPortNames();
            foreach (string portname in portnames)
            {
                if (port != null) port.Close();
                port.PortName = portname;
                try
                {
                    port.Open();
                    if (c_who(port, null))
                    {
                        logger.Info($"{name}: устройство автоматически определено ({portname})");
                        return portname;
                    }
                }
                catch (System.IO.IOException) { }
                catch (InvalidOperationException) { }
                catch (OpenOrWriteException) { }
                catch (ReadException) { }
                catch (UnauthorizedAccessException) { }
                finally
                {
                    if (port != null) port.Close();
                }
            }
            logger.Warn($"{name}: автопоиск завершился неудачей");
            return null;
        }
        #endregion

        //---------------------------------------------------------------------------

        private void singleRun_processing(ref bool needErrorTimeout)
        {
            logger.Trace($"{name}: выполнение команды " + (dataUI_forStream.single ? "SINGLE" : "RUN"));
            try
            {
                reopen();
                byte[] received = c_fdk(dataUI_forStream.osn, dataUI_forStream.dop, dataUI_forStream.main, dataUI_forStream.need_log);
                set_FDKData__toUI(ref received, dataUI_forStream.single, dataUI_forStream.run);
            }
            catch (OpenOrWriteException err)
            {
                log(err.Message, System.Drawing.Color.Red);
                logger.Warn($"{name}: {err.Message}");
                setConnectivity_toUI(new Connectivity(dataUI_forStream.single, dataUI_forStream.run, Connectivity.Connect_status.error));
                if (dataUI_forStream.run) needErrorTimeout = true;
            }
            catch (ReadException err)
            {
                log(err.Message, System.Drawing.Color.Red);
                logger.Warn($"{name}: {err.Message}");
                setConnectivity_toUI(new Connectivity(dataUI_forStream.single, dataUI_forStream.run, Connectivity.Connect_status.error));
            }
            finally
            {
                close();
            }

            if (dataUI_forStream.single)
            {
                dataUI_forStream.single = false;
                lock (dataLocker)
                {
                    dataUI.single = false;
                }
                UI.disableSINGLE();
                logger.Trace($"{name}: отработана команда SINGLE");
            }
            else
            {
                logger.Trace($"{name}: отработана команда RUN");
            }
        }
        private void findDevice(bool need_log, ref bool needErrorTimeout)
        {
            logger.Info($"{name}: Поиск устройства...");
            lock (dataLocker)
            {
                dataUI.autoDetectInFirstStartup = false;
                if (comport != null) comport.Close();
                comport.BaudRate = Properties.Settings.Default.baudrate;
                comport.Parity = Properties.Settings.Default.parity;
                comport.DataBits = Properties.Settings.Default.dataBits;
                comport.StopBits = Properties.Settings.Default.stopBits;
            }
            comport.Handshake = Handshake.None;
            comport.ReadTimeout = 100;
            comport.WriteTimeout = 100;
            string[] portnames = SerialPort.GetPortNames();
            foreach (string portname in portnames)
            {
                if (comport != null) comport.Close();
                comport.PortName = portname;
                try
                {
                    comport.Open();
                    Action<string, System.Drawing.Color> addlog = null;
                    if (need_log) addlog = UI.AddLog;
                    if (c_who(comport, addlog))
                    {
                        lock(dataLocker)
                        {
                            Properties.Settings.Default.portname = portname;
                            Properties.Settings.Default.Save();
                        }
                        log($"устройство определено ({comport.PortName})", System.Drawing.Color.LimeGreen);
                        logger.Info($"{name}: устройство определено ({comport.PortName})");
                        return;
                    }
                }
                catch (System.IO.IOException) { }
                catch (InvalidOperationException) { }
                catch (OpenOrWriteException) { }
                catch (ReadException) { }
                catch (UnauthorizedAccessException) { }
                finally
                {
                    if (comport != null) comport.Close();
                }
            }
            if (comport != null) comport.Close();
            lock (dataLocker)
            {
                if(!string.IsNullOrEmpty(Properties.Settings.Default.portname)) comport.PortName = Properties.Settings.Default.portname;
            }
            log("устройство не найдено", System.Drawing.Color.Red);
            logger.Warn($"{name}: устройство не найдено");
            needErrorTimeout = true;
        }
        /// <summary>
        /// функция потока
        /// </summary>
        public void stream()
        {
            logger.Info("поток для общения с устройством запущен");
            try
            {
                bool needErrorTimeout = false;
                while (true)
                {
                    Thread.Sleep(needErrorTimeout ? 500 : 1);   // При наличии ошибок в обмене на предыдущей итерации, увеличиваем паузу между итерациями
                    needErrorTimeout = false;

                    applyData_toStream();   // Забираем данные извне, с которыми будем безопасно работать в потоке
                    if (dataUI_forStream.autoDetectInFirstStartup)
                    {
                        findDevice(dataUI_forStream.need_log, ref needErrorTimeout);
                    }
                    else if (dataUI_forStream.single || dataUI_forStream.run)
                    {
                        singleRun_processing(ref needErrorTimeout);
                    }
                }
            }
            finally
            {
                close();
                logger.Info("поток для общения с устройством закрыт");
            }
        }

        //---------------------------------------------------------------------------
    }
}
