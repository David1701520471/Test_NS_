
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models.Transport
{
    public class Transport
    {
        public Transport() { 
        }

        [Key]
        [Required]
        public string FlightNumber { get; set; }
    }
}