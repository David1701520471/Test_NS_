using System;
using System.Runtime.Serialization;

namespace TestMVC.DbAccess.Exeptions
{
    public class MissingFlightDataException : Exception
    {
        public MissingFlightDataException()
        {
        }

        public MissingFlightDataException(string message) : base(message)
        {
        }

        public MissingFlightDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingFlightDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}