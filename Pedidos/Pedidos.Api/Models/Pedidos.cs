using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pedidos.Api.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Pedido>? Pedidos { get; set; }
    }

    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public int IdCliente { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

       
        public virtual ICollection<DetallePedido>? Detalles { get; set; }
    }

    public class DetallePedido
    {
        [Key]
        public int IdDetalle { get; set; }

        public int IdPedido { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdPedido")]
        public virtual Pedido? Pedido { get; set; }

        public int IdProducto { get; set; } 
        public int Cantidad { get; set; }
    }
}
