using HiveService.API.Domain;
using HiveService.API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HiveService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HiveController : ControllerBase
    {
        private readonly HiveDbContext _context;

        public HiveController(HiveDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hive>>> GetHives([FromQuery] string? status)
        {
            var query = _context.Hives.AsQueryable();
            if (!string.IsNullOrEmpty(status) && status != "all")
            {
                query = query.Where(h => h.HealthStatus == status);
            }
            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Hive>> CreateHive(Hive hive)
        {
            _context.Hives.Add(hive);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHives), new { id = hive.HiveId }, hive);
        }
    }
}
