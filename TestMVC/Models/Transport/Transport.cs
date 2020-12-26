
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models.Transport
{
    public class Transport
    {
        public Transport() { 
        }

        [Key]
        public string FlightNumber { get; set; }
    }
}