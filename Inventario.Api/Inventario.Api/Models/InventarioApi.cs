using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inventario.Api.Models
{
    public class Bodega
    {
        [Key]
        public int IdBodega { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        
        [JsonIgnore]
        public virtual ICollection<Existencia>? Existencias { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovimientoInv>? Movimientos { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReservaStock>? Reservas { get; set; }
    }

    public class Existencia
    {
        [Key]
        public int IdExistencia { get; set; }

        public int IdBodega { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdBodega")]
        public virtual Bodega? Bodega { get; set; }

        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

    public class MovimientoInv
    {
        [Key]
        public int IdMovimiento { get; set; }

        public int IdBodega { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdBodega")]
        public virtual Bodega? Bodega { get; set; }

        public int IdProducto { get; set; }
        public string? Tipo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }

    public class ReservaStock
    {
        [Key]
        public int IdReserva { get; set; }

        public int IdBodega { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdBodega")]
        public virtual Bodega? Bodega { get; set; }

        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}

