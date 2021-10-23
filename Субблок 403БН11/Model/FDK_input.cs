using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialport_communication.Model
{
    class FDK_input
    {
        /// <summary>
        /// выходное напряжение ; признак аварийности значения
        /// </summary>
        public Tuple<double?, bool> plus50v_osn;
        public Tuple<double?, bool> plus50v_dop;
        public Tuple<double?, bool> plus50v;
        public Tuple<double?, bool> plus300v;
        public Tuple<double?, bool> plus5v;
        public Tuple<double?, bool> plus12v;
        public Tuple<double?, bool> minus12v;

        public FDK_input()
        {
            plus50v_osn = new Tuple<double?, bool>(null, false);
            plus50v_dop = new Tuple<double?, bool>(null, false);
            plus50v     = new Tuple<double?, bool>(null, false);
            plus300v    = new Tuple<double?, bool>(null, false);
            plus5v      = new Tuple<double?, bool>(null, false);
            plus12v     = new Tuple<double?, bool>(null, false);
            minus12v    = new Tuple<double?, bool>(null, false);
        }
    }
}
