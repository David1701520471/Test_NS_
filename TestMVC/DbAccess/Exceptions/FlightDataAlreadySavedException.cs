using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestMVC.DbAccess.Exeptions
{
    public class FlightDataAlreadySavedException : Exception
    {
        public FlightDataAlreadySavedException()
        {
        }

        public FlightDataAlreadySavedException(string message) : base(message)
        {
        }

        public FlightDataAlreadySavedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlightDataAlreadySavedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}