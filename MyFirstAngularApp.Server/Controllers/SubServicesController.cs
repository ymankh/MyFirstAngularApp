using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAngularApp.Server.Models;

namespace MyFirstAngularApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubService>>> GetSubServices()
        {
            return await _context.SubServices.ToListAsync();
        }

        // GET: api/SubServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubService>> GetSubService(int id)
        {
            var subService = await _context.SubServices.FindAsync(id);

            if (subService == null)
            {
                return NotFound();
            }

            return subService;
        }

        // PUT: api/SubServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubService(int id, SubService subService)
        {
            if (id != subService.SubServiceID)
            {
                return BadRequest();
            }

            _context.Entry(subService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SubServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubService>> PostSubService(SubServiceDto subServiceDto)
        {

            var subService = new SubService
            {
                SubServiceName = subServiceDto.SubServiceName,
                SubServiceImage = subServiceDto.SubServiceImage,
                ServiceID = subServiceDto.ServiceID,
                SubServiceDescription = subServiceDto.SubServiceName
            };
            _context.SubServices.Add(subService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubService", new { id = subService.ServiceID }, subService);
        }

        // DELETE: api/SubServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubService(int id)
        {
            var subService = await _context.SubServices.FindAsync(id);
            if (subService == null)
            {
                return NotFound();
            }

            _context.SubServices.Remove(subService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubServiceExists(int id)
        {
            return _context.SubServices.Any(e => e.SubServiceID == id);
        }
    }
    public class SubServiceDto
    {

        public string SubServiceName { get; set; }

        public string SubServiceDescription { get; set; }

        public string SubServiceImage { get; set; }

        public int ServiceID { get; set; }

    }
}
