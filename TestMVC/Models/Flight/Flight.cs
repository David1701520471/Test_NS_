using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMVC.Models.Flight
{
    public class Flight
    {
        public Flight()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string DepartureStation { get; set; }
        [Required]
        public string ArrivalStation { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [ForeignKey("FkTransport")]
        public Transport.Transport Transport { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Currency { get; set; }
    }
}