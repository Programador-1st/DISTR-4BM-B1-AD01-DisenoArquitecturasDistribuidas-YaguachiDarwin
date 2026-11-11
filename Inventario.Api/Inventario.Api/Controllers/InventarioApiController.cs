using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public BodegasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
            => await _context.Bodegas.AsNoTracking().ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            return bodega == null ? NotFound() : bodega;
        }

        [HttpPost]
        public async Task<ActionResult<Bodega>> CrearBodega(Bodega bodega)
        {
            _context.Bodegas.Add(bodega);
            await _context.SaveChangesAsync();
            return Ok(bodega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarBodega(int id, Bodega bodega)
        {
            if (id != bodega.IdBodega) return BadRequest();
            _context.Entry(bodega).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { return BadRequest(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarBodega(int id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null) return NotFound();
            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

 


    [Route("api/Existencias")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ExistenciasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistencias()
            => await _context.Existencias.Include(e => e.Bodega).AsNoTracking().ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Existencia>> GetExistencia(int id)
        {
            var existencia = await _context.Existencias.Include(e => e.Bodega).FirstOrDefaultAsync(e => e.IdExistencia == id);
            return existencia == null ? NotFound() : existencia;
        }

        [HttpPost]
        public async Task<ActionResult<Existencia>> CrearExistencia(Existencia existencia)
        {
            _context.Existencias.Add(existencia);
                await _context.SaveChangesAsync();
            return Ok(existencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarExistencia(int id, Existencia existencia)
        {
            if (id != existencia.IdExistencia) return BadRequest();
            _context.Entry(existencia).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { return BadRequest(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarExistencia(int id)
        {
            var existencia = await _context.Existencias.FindAsync(id);
            if (existencia == null) return NotFound();
            _context.Existencias.Remove(existencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

 


    [Route("api/Movimientos")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public MovimientosController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInv>>> GetMovimientos()
            => await _context.Movimientos_Inv.Include(m => m.Bodega).AsNoTracking().ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInv>> GetMovimiento(int id)
        {
            var movimiento = await _context.Movimientos_Inv.Include(m => m.Bodega).FirstOrDefaultAsync(m => m.IdMovimiento == id);
            return movimiento == null ? NotFound() : movimiento;
        }

        [HttpPost]
        public async Task<ActionResult<MovimientoInv>> CrearMovimiento(MovimientoInv movimiento)
        {
            _context.Movimientos_Inv.Add(movimiento);
            await _context.SaveChangesAsync();
            return Ok(movimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMovimiento(int id, MovimientoInv movimiento)
        {
            if (id != movimiento.IdMovimiento) return BadRequest();
            _context.Entry(movimiento).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { return BadRequest(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarMovimiento(int id)
        {
            var movimiento = await _context.Movimientos_Inv.FindAsync(id);
            if (movimiento == null) return NotFound();
            _context.Movimientos_Inv.Remove(movimiento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }



    [Route("api/ReservaStock")]
    [ApiController]
    public class ReservaStockController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ReservaStockController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaStock>>> GetReservas()
            => await _context.ReservaStock.Include(r => r.Bodega).AsNoTracking().ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaStock>> GetReserva(int id)
        {
            var reserva = await _context.ReservaStock.Include(r => r.Bodega).FirstOrDefaultAsync(r => r.IdReserva == id);
            return reserva == null ? NotFound() : reserva;
        }

        [HttpPost]
        public async Task<ActionResult<ReservaStock>> CrearReserva(ReservaStock reserva)
        {
            _context.ReservaStock.Add(reserva);
            await _context.SaveChangesAsync();
            return Ok(reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarReserva(int id, ReservaStock reserva)
        {
            if (id != reserva.IdReserva) return BadRequest();
            _context.Entry(reserva).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateException) { return BadRequest(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarReserva(int id)
        {
            var reserva = await _context.ReservaStock.FindAsync(id);
            if (reserva == null) return NotFound();
            _context.ReservaStock.Remove(reserva);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
