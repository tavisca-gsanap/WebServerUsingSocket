using System;
using System.Runtime.Serialization;

namespace WebServerUsingSocket
{
    [Serializable]
    internal class InvalidFileSystemException : Exception
    {
        public InvalidFileSystemException()
        {
        }

        public InvalidFileSystemException(string message) : base(message)
        {
        }

        public InvalidFileSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFileSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}