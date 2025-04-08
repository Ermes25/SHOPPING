using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Required]
        [MaxLength(100)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        public bool activo { get; set; }
    }
}
