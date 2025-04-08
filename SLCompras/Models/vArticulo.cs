using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Models
{
    [Table("vArticulos")]
    public class vArticulo
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
        [MaxLength(100)]
        [Required]
        public string nombre { get; set; } = string.Empty;
        [Required]
        public bool activo { get; set; }
    }
}
