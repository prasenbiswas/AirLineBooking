using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
{
    public class Passenger
    {
        [Key]
        public Guid Id { get; set; }
        public string BookReference { get; set; }   //unique
        public string Name { get; set; }
        public int Age { get; set; }
        public string FlightNumber { get; set; }
    }
}
