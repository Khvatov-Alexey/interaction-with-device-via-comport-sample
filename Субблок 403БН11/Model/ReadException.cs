using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialport_communication.Model
{
    public class ReadException : ApplicationException
    {
        public ReadException() { }

        public ReadException(string message) : base(message) { }

        public ReadException(string message, Exception inner) : base(message, inner) { }

        protected ReadException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
