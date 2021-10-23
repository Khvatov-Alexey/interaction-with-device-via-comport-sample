using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialport_communication.Model
{
    public class Connectivity
    {
        public enum Connect_status
        {
            disable = 0,
            error,
            success
        }

        public bool single;
        public bool run;
        public Connect_status connect_status;

        public Connectivity()
        {
            single = false;
            run = false;
            connect_status = Connect_status.disable;
        }
        public Connectivity(bool single, bool run, Connect_status connect_status)
        {
            this.single = single;
            this.run = run;
            this.connect_status = connect_status;
        }
    }
}
