using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestMVC.Models.SearchData
{
    public class SearchMissedFieldException : Exception
    {
        public SearchMissedFieldException()
        {
        }

        public SearchMissedFieldException(string message) : base(message)
        {
        }

        public SearchMissedFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SearchMissedFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}