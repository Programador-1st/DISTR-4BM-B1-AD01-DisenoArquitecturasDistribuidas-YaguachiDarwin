using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public ClientesController(PedidosDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
            => await _context.Clientes.AsNoTracking().ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente == null ? NotFound() : cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente) return BadRequest();
            _context.Entry(cliente).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { return BadRequest(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

  


    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public PedidosController(PedidosDbContext context) => _context = context;

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
            => await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .AsNoTracking()
                .ToListAsync();

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            return pedido == null ? NotFound() : pedido;
        }

        
        [HttpPost]
        public async Task<ActionResult<Pedido>> CrearPedido(Pedido pedido)
        {
            
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return Ok(pedido);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedido(int id, Pedido pedido)
        {
            if (id != pedido.IdPedido) return BadRequest("El ID de la URL no coincide con el ID del cuerpo.");

            
            pedido.Detalles = null;

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {            
                return BadRequest($"Error al actualizar: {ex.InnerException?.Message}");
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarPedido(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null) return NotFound();

            
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}




[Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public DetallesPedidosController(PedidosDbContext context) => _context = context;

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetalles()
            => await _context.DetallesPedidos.AsNoTracking().ToListAsync();

        
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetalle(int id)
        {
            var detalle = await _context.DetallesPedidos.FindAsync(id);
            return detalle == null ? NotFound() : detalle;
        }

        
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> CrearDetalle(DetallePedido detalle)
        {
            _context.DetallesPedidos.Add(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalle(int id, DetallePedido detalle)
        {
            if (id != detalle.IdDetalle) return BadRequest("El ID de la URL no coincide con el ID del cuerpo.");

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Error al actualizar: {ex.InnerException?.Message}");
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarDetalle(int id)
        {
            var detalle = await _context.DetallesPedidos.FindAsync(id);
            if (detalle == null) return NotFound();

            _context.DetallesPedidos.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
