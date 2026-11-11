using Catalogo.Api.Data;
using Catalogo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly CatalogoDbContext _context;

        public CatalogoController(CatalogoDbContext context)
        {
            _context = context;
        }

       

        [Tags("Categorias")]
        [HttpGet("categorias")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias() => await _context.Categoria.AsNoTracking().ToListAsync();

        [Tags("Categorias")]
        [HttpGet("categorias/{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            return categoria == null ? NotFound() : categoria;
        }

        [Tags("Categorias")]
        [HttpPost("categorias")]
        public async Task<ActionResult<Categoria>> CrearCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.IdCategoria }, categoria);
        }

        [Tags("Categorias")]
        [HttpPut("categorias/{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria) return BadRequest();
            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [Tags("Categorias")]
        [HttpDelete("categorias/{id}")]
        public async Task<IActionResult> BorrarCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null) return NotFound();

            _context.Categoria.Remove(categoria);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return NoContent();
        }


       

        [Tags("Marcas")]
        [HttpGet("marcas")]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas() => await _context.Marca.AsNoTracking().ToListAsync();

        [Tags("Marcas")]
        [HttpGet("marcas/{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            return marca == null ? NotFound() : marca;
        }

        [Tags("Marcas")]
        [HttpPost("marcas")]
        public async Task<ActionResult<Marca>> CrearMarca(Marca marca)
        {
            _context.Marca.Add(marca);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMarca), new { id = marca.IdMarca }, marca);
        }

        [Tags("Marcas")]
        [HttpPut("marcas/{id}")]
        public async Task<IActionResult> ActualizarMarca(int id, Marca marca)
        {
            if (id != marca.IdMarca) return BadRequest();
            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [Tags("Marcas")]
        [HttpDelete("marcas/{id}")]
        public async Task<IActionResult> BorrarMarca(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            if (marca == null) return NotFound();

            _context.Marca.Remove(marca);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return NoContent();
        }


        

        [Tags("Productos")]
        [HttpGet("productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
            => await _context.Producto.Include(p => p.Marca).Include(p => p.Categoria).AsNoTracking().ToListAsync();

        [Tags("Productos")]
        [HttpGet("productos/{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.IdProducto == id);

            return producto == null ? NotFound() : producto;
        }

        [Tags("Productos")]
        [HttpPost("productos")]
        public async Task<ActionResult<Producto>> CrearProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetProducto), new { id = producto.IdProducto }, producto);
        }

        [Tags("Productos")]
        [HttpPut("productos/{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto) return BadRequest();
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [Tags("Productos")]
        [HttpDelete("productos/{id}")]
        public async Task<IActionResult> BorrarProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Producto.Remove(producto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}