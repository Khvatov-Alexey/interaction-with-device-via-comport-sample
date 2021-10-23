using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialport_communication.Model
{
    public class OpenOrWriteException : ApplicationException
    {
        public OpenOrWriteException() { }

        public OpenOrWriteException(string message) : base(message) { }

        public OpenOrWriteException(string message, Exception inner) : base(message, inner) { }

        protected OpenOrWriteException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
