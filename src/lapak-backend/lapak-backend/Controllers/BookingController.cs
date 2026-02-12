using Microsoft.AspNetCore.Mvc;
using lapak_backend.Models;

namespace lapak_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private static readonly List<Booking> Bookings = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Bookings);
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            booking.Id = Bookings.Count + 1;
            Bookings.Add(booking);
            return Ok(booking);
        }
    }
}