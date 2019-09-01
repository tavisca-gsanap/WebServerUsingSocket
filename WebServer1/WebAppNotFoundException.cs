using System;
using System.Runtime.Serialization;

namespace WebServerUsingSocket
{
    [Serializable]
    internal class WebAppNotFoundException : Exception
    {
        public WebAppNotFoundException()
        {
        }

        public WebAppNotFoundException(string message) : base(message)
        {
        }

        public WebAppNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebAppNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}