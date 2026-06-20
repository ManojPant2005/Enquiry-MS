using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Api.Data;
using Angular.Api.Data.Entities;

namespace Angular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly EnquiryDbContext _context;

        public EnquiryController(EnquiryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnquiryMaster>>> GetEnquiryMasters()
        {
            return await _context.EnquiryMasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnquiryMaster>> GetEnquiryMaster(int id)
        {
            var enquiryMaster = await _context.EnquiryMasters.FindAsync(id);

            if (enquiryMaster == null)
            {
                return NotFound();
            }

            return enquiryMaster;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnquiryMaster(int id, EnquiryMaster enquiryMaster)
        {
            if (id != enquiryMaster.EnquiryId)
            {
                return BadRequest();
            }

            _context.Entry(enquiryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnquiryMasterExists(id))
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

        [HttpPost]
        public async Task<ActionResult<EnquiryMaster>> PostEnquiryMaster(EnquiryMaster enquiryMaster)
        {
            _context.EnquiryMasters.Add(enquiryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnquiryMaster", new { id = enquiryMaster.EnquiryId }, enquiryMaster);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnquiryMaster(int id)
        {
            var enquiryMaster = await _context.EnquiryMasters.FindAsync(id);
            if (enquiryMaster == null)
            {
                return NotFound();
            }

            _context.EnquiryMasters.Remove(enquiryMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnquiryMasterExists(int id)
        {
            return _context.EnquiryMasters.Any(e => e.EnquiryId == id);
        }
    }
}
