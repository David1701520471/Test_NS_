using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.ExternalAPI.Response
{
    public class ResAPI
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}