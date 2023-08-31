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
    public class EstadoPedidoController : ControllerBase
    {
        private readonly BDE71298136Context _context;

        public EstadoPedidoController(BDE71298136Context context)
        {
            _context = context;
        }

        // GET: api/EstadoPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPedido>>> GetEstadoPedidos()
        {
            return await _context.EstadoPedidos.ToListAsync();
        }

        // GET: api/EstadoPedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPedido>> GetEstadoPedido(int id)
        {
            var estadoPedido = await _context.EstadoPedidos.FindAsync(id);

            if (estadoPedido == null)
            {
                return NotFound();
            }

            return estadoPedido;
        }

        // PUT: api/EstadoPedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPedido(int id, EstadoPedido estadoPedido)
        {
            if (id != estadoPedido.IdEstadoPedido)
            {
                return BadRequest();
            }

            _context.Entry(estadoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPedidoExists(id))
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

        // POST: api/EstadoPedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPedido>> PostEstadoPedido(EstadoPedido estadoPedido)
        {
            _context.EstadoPedidos.Add(estadoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPedido", new { id = estadoPedido.IdEstadoPedido }, estadoPedido);
        }

        // DELETE: api/EstadoPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPedido(int id)
        {
            var estadoPedido = await _context.EstadoPedidos.FindAsync(id);
            if (estadoPedido == null)
            {
                return NotFound();
            }

            _context.EstadoPedidos.Remove(estadoPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPedidoExists(int id)
        {
            return _context.EstadoPedidos.Any(e => e.IdEstadoPedido == id);
        }
    }
}
