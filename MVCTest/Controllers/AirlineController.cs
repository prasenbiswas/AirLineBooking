using Microsoft.AspNetCore.Mvc;
using MVCTest.Models;
using MVCTest.Repository;

namespace MVCTest.Controllers
{
    public class AirlineController : Controller
    {
        private readonly IGenericRepository<Flight> _genericsRepository;
        private readonly IGenericRepository<Passenger> _genericsPassenger;
        public AirlineController(IGenericRepository<Flight> genericsRepository, IGenericRepository<Passenger> genericsPassenger)
        {
            _genericsRepository = genericsRepository;
            _genericsPassenger = genericsPassenger;
        }
        public IActionResult Index()
        {
            var data = _genericsRepository.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFlight(Flight flight)
        {
            var flights = new Flight
            {
                FlightNumber = flight.FlightNumber,
                DepartureCity = flight.DepartureCity,
                ArrivalCity = flight.ArrivalCity,
                DepartureTime = flight.DepartureTime,
                AvailableSpace = flight.AvailableSpace
            };
            _genericsRepository.Insert(flights);
            _genericsRepository.Save();
            return RedirectToAction("Index", "Airline");
        }
        [HttpGet]
        public IActionResult FlightBooking([FromRoute] string FlightNumber)
        {
            if (FlightNumber != null)
            {
                Flight data = _genericsRepository.GetById(FlightNumber);
                Passenger passenger = new Passenger();
                passenger.FlightNumber = data.FlightNumber;
            }
            return View();
        }

        [HttpPost]
        public IActionResult FlightBooking(Passenger passenger)
        {
            var passengers = new Passenger
            {
                FlightNumber = passenger.FlightNumber,
                Name = passenger.Name,
                BookReference = passenger.BookReference,
                Age = passenger.Age
            };
            _genericsPassenger.Insert(passengers);
            _genericsPassenger.Save();
            return RedirectToAction("Index", "Airline");
        }
        public IActionResult GetBooking()
        {
            var data = _genericsPassenger.GetAll();
            return View(data);
        }
    }
}
