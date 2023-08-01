using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }
        public string FlightNumber { get; set; } //unique
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSpace { get; set; }
    }
}
