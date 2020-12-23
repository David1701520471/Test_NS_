

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Transport; 

namespace Domain.Flight
{
    public class Flight
    {
        [Key]
        public int Id{ get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public ICollection<Transport.Transport> Transport{ get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
