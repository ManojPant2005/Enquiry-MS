using Angular.Api.Data;
using Angular.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceMasterController : ControllerBase
    {
        private readonly EnquiryDbContext dbContext;
        public ServiceMasterController(EnquiryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetAllServices()
        {
            var services = await dbContext.Services.ToListAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> GetServiceById(int id)
        {
            var service = await dbContext.Services.FindAsync(id);
            if (service == null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Services>> CreateService(Services service)
        {
            service.CreatedDate = DateTime.UtcNow;
            dbContext.Services.Add(service);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceId }, service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Services service)
        {
            if (id != service.ServiceId)
                return BadRequest();

            var existing = await dbContext.Services.FindAsync(id);
            if (existing == null)
                return NotFound();

            // update allowed fields
            existing.ServiceName = service.ServiceName;
            existing.IsActive = service.IsActive;
            existing.Rate = service.Rate;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var existing = await dbContext.Services.FindAsync(id);
            if (existing == null)
                return NotFound();

            dbContext.Services.Remove(existing);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
