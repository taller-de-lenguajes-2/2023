using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EjemploN5
{
    class ConfigFileDontFoundException : Exception
    {
        public ConfigFileDontFoundException()
        {
        }

        public ConfigFileDontFoundException(string message) : base(message)
        {
        }

        public ConfigFileDontFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConfigFileDontFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
