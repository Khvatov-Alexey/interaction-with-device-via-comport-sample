using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialport_communication.Model
{
    public class FDK_output
    {
        public double Plus50v_osn;
        public double Plus50v_dop;
        public double Plus50v;

        public FDK_output(double Plus50v_osn, double Plus50v_dop, double Plus50v)
        {
            this.Plus50v_osn = Plus50v_osn;
            this.Plus50v_dop = Plus50v_dop;
            this.Plus50v = Plus50v;
        }
    }
}
