using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SLCompras.Models
{
    [Table("vcontrolacs")]
    public class vControlac
    {
        [Key]
        public int idCategoria { get; set; }
        [Required]
        [MaxLength(100)]
        public string categoria { get; set; } = string.Empty;
        public int? cantidadArticulos { get; set; }
        public decimal? totalPrecio { get; set; }
    }
}
