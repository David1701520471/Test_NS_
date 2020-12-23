

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Transport
{
    public class Transport
    {
        [Key]
        public string FlightNumber { get; set; }
    }
}
