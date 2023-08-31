using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly BDE71298136Context _context;

        public CarritoController(BDE71298136Context context)
        {
            _context = context;
        }

        // GET: api/Carrito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrito>>> GetCarritos()
        {
            return await _context.Carritos.ToListAsync();
        }

        // GET: api/Carrito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrito>> GetCarrito(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);

            if (carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }

        // GET: api/Carrito/5
        [HttpGet("Usuario/{IdUsuario}/Producto/{IdProducto}")]
        public async Task<ActionResult<Carrito>> BuscarItemCarritoExistente(string IdUsuario, int IdProducto)
        {
            var itemCarrito = await _context.Carritos.FirstOrDefaultAsync(m => m.UserId == IdUsuario && m.IdProducto == IdProducto && m.Activo == true);

            if (itemCarrito == null)
            {
                return NotFound();
            }

            return itemCarrito;
        }


        [Route("ProductosSeleccionados")]
        [HttpGet]
        public ActionResult<IEnumerable<VMCarrito>> GetProductosCarrito(string IdUsuario)
        {
            var productosSeleccionados = (from p in _context.Productos
                                          join ca in _context.Carritos on p.IdProducto equals ca.IdProducto
                                          join u in _context.AspNetUsers on ca.UserId equals u.Id
                                          where u.Id == IdUsuario && ca.Activo == true
                                          select new VMCarrito
                                          {
                                              IdCarrito = ca.IdCarrito,
                                              Nombre = p.Nombre,
                                              Descripcion = p.Descripcion,
                                              Imagen = p.Imagen,
                                              PrecioLista = p.PrecioLista,
                                              Precio = p.Precio,
                                              Cantidad = ca.Cantidad,
                                              SubTotal = ca.SubTotal,
                                              Descuento = p.Descuento
                                          }).ToList();



            return Ok(productosSeleccionados);
        }



        // PUT: api/Carrito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrito(int id, Carrito carrito)
        {
            if (id != carrito.IdCarrito)
            {
                return BadRequest();
            }

            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoExists(id))
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

        // POST: api/Carrito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrito>> PostCarrito(Carrito carrito)
        {
            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrito", new { id = carrito.IdCarrito }, carrito);
        }

        // DELETE: api/Carrito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrito(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.IdCarrito == id);
        }
    }
}
