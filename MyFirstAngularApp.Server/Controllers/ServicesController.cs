using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAngularApp.Server.Models;
using MyFirstAngularApp.Server.DTOs.ServiceDTOs;
using MyFirstAngularApp.Server.shared;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MyFirstAngularApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.Include(s => s.SubServices).FirstOrDefaultAsync(s => s.ServiceID == id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutService(int id, Service service)
        // {
        //     if (id != service.ServiceID)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(service).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ServiceExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService([FromForm] CreateServiceDto service)
        {
            var serviceImage = ImageSaver.SaveImage(service.ServiceImage);
            var newService = new Service
            {
                ServiceName = service.ServiceName,
                ServiceDescription = service.ServiceDescription,
                ServiceImage = serviceImage,

            };

            _context.Services.Add(newService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = newService.ServiceID }, service);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateService(int id, [FromForm] CreateServiceDto service)
        {

            var oldService = _context.Services.Find(id);
            if (oldService == null)
                return NotFound();
            var serviceImage = oldService.ServiceImage;
            if (service.ServiceImage != null)
                serviceImage = ImageSaver.SaveImage(service.ServiceImage);


            oldService.ServiceName = service.ServiceName;
            oldService.ServiceDescription = service.ServiceDescription;
            oldService.ServiceImage = serviceImage;

            _context.Services.Update(oldService);
            _context.SaveChanges();

            return CreatedAtAction("GetService", new { id = oldService.ServiceID }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceID == id);
        }
    }


}
