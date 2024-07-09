using System;

namespace MicroondasDigital.Core.Exceptions
{
    public class MicroondasException : Exception
    {
        public MicroondasException() { }

        public MicroondasException(string message) : base(message) { }

        public MicroondasException(string message, Exception innerException) : base(message, innerException) { }
    }
}
