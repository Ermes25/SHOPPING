using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Models
{
    [Table("Articulos")]
    public class Articulo
    {
       
        [Key]
        public int idArticulo { get; set; }
        [MaxLength(100)]
        [Required]
        public string nombreArticulo { get; set; } = string.Empty;
        [Required]
        public int cantidad { get; set; }
        [Required]
        public decimal precio { get; set; }
        public int? idCategoria { get; set; }
        [Required]
        public bool activo { get; set; } = true;
        [Required]
        public DateTime fechaCreacion { get; set; } = DateTime.Now;
       

    }
}
