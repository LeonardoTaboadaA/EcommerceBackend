using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController : ControllerBase
    {
        private readonly BDE71298136Context _context;

        public CuponController(BDE71298136Context context)
        {
            _context = context;
        }

        // GET: api/Cupon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cupon>>> GetCupons()
        {
            return await _context.Cupons.ToListAsync();
        }

        // GET: api/Cupon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cupon>> GetCupon(int id)
        {
            var cupon = await _context.Cupons.FindAsync(id);

            if (cupon == null)
            {
                return NotFound();
            }

            return cupon;
        }

        // PUT: api/Cupon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupon(int id, Cupon cupon)
        {
            if (id != cupon.IdCupon)
            {
                return BadRequest();
            }

            _context.Entry(cupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuponExists(id))
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

        // POST: api/Cupon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cupon>> PostCupon(Cupon cupon)
        {
            _context.Cupons.Add(cupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCupon", new { id = cupon.IdCupon }, cupon);
        }

        // DELETE: api/Cupon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupon(int id)
        {
            var cupon = await _context.Cupons.FindAsync(id);
            if (cupon == null)
            {
                return NotFound();
            }

            _context.Cupons.Remove(cupon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuponExists(int id)
        {
            return _context.Cupons.Any(e => e.IdCupon == id);
        }
    }
}
