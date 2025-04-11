using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLCompras.Models;

namespace SLCompras.Controllers
{
    public class dbContext : DbContext
    {
        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public DbSet<vArticulo> vArticulos { get; set; }
        public DbSet<vControlac> vControlacs { get; set; }
        public DbSet<vControlArticulo> vControlArticulos { get; set; }
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
