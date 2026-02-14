using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lapak_backend.Data;
using lapak_backend.Models;

namespace lapak_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BuildingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
            return Ok(building);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null) return NotFound();

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}