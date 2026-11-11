using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Catalogo.Api.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // ESTO CORTA EL CICLO
        [JsonIgnore]
        public virtual ICollection<Producto>? Productos { get; set; }
    }

    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        
        [JsonIgnore]
        public virtual ICollection<Producto>? Productos { get; set; }
    }

    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        public int IdMarca { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdMarca")]
        public virtual Marca? Marca { get; set; }

        public int IdCategoria { get; set; }

        [JsonIgnore] 
        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }
    }
}
