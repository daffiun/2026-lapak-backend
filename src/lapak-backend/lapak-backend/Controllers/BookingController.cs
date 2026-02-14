using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lapak_backend.Data;
using lapak_backend.Models;

namespace lapak_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        // FITUR: Penelusuran & Riwayat Peminjaman
        // GET: api/booking?status=Pending&search=Aulia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings([FromQuery] string? status, [FromQuery] string? search)
        {
            var query = _context.Bookings.Include(b => b.Room).AsQueryable();

            // Filter berdasarkan Status (Pending/Disetujui/Ditolak)
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(b => b.Status == status);
            }

            // Pencarian berdasarkan Nama Peminjam atau NRP
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.BorrowerName.Contains(search) || b.BorrowerNrp.Contains(search));
            }

            return await query.OrderByDescending(b => b.BookingDate).ToListAsync();
        }

        // FITUR: Pencatatan Peminjaman Ruangan
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            booking.BookingDate = DateTime.UtcNow;
            booking.Status = "Pending"; // Default awal sesuai permintaan

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        // FITUR: Pengelolaan Status Peminjaman
        // PATCH: api/booking/5/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            // Ubah status: Menunggu Persetujuan, Disetujui, atau Ditolak
            booking.Status = newStatus;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/booking/5 (Menghapus data peminjaman)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}