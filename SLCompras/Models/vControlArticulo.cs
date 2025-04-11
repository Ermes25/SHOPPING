using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SLCompras.Models
{
    [Table("vControlArticulos")]
    public class vControlArticulo
    {
        [Key]
        public int idArticulo { get; set; }

        [MaxLength(100)]
        [Required]
        public string nombreArticulo { get; set; } = string.Empty;

        public int? idCategoria { get; set; }   // Puede ser null si no hay categoría asignada

        [MaxLength(100)]
        public string? nombre { get; set; }

        public int cantidad { get; set; }

        public decimal precio { get; set; }

        public decimal PrecioTotal { get; set; }
    }
}
