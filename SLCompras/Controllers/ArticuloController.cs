using Microsoft.EntityFrameworkCore;
using SLCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Controllers
{
    public interface IArticuloController
    {
        Task<List<vArticulo>> GetArticulos();
        Task<vArticulo> GetvArticulo(int Id);
        Task<List<Categoria>> GetCategorias();
        Task<int> Insert(Articulo Entidad);
        Task<bool> Update(Articulo Entidad);
        Task<bool> Delete(Articulo Entidad);
    }
    public class ArticuloController : IArticuloController
    {
        readonly IDbContextFactory<dbContext> db;

        public ArticuloController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }

        public async Task<List<vArticulo>> GetArticulos()
        {
            using var context = db.CreateDbContext();
            return await context.vArticulos.Where(b => b.activo).ToListAsync();
        }
        public async Task<vArticulo> GetvArticulo(int Id)
        {
            using var conexion = db.CreateDbContext();
            return await conexion.vArticulos.FindAsync(Id) ?? new();
        }
        public async Task<List<Categoria>> GetCategorias()
        {
            using var conexion = db.CreateDbContext();
            return await conexion.Categorias.ToListAsync();
        }

        public async Task<int> Insert(Articulo Entidad)
        {
            using var context = db.CreateDbContext();
            Entidad.activo = true;
            Entidad.fechaCreacion = DateTime.Now;
            context.Articulos.Add(Entidad);
            await context.SaveChangesAsync();
            return Entidad.idArticulo;
        }

        public async Task<bool> Update(Articulo Entidad)
        {
            using var conexion = db.CreateDbContext();
            var Registro = await conexion.Articulos.FindAsync(Entidad.idArticulo);
            if (Registro != null) {
                Registro.nombreArticulo = Entidad.nombreArticulo;
                Registro.cantidad = Entidad.cantidad;
                Registro.precio = Entidad.precio;
                Registro.idCategoria = Entidad.idCategoria;
                Registro.fechaCreacion = DateTime.Now;
                return await conexion.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> Delete(Articulo Entidad)
        {
            using var conexion = db.CreateDbContext();
            var Registro = await conexion.Articulos.Where(a => a.idArticulo == Entidad.idArticulo).SingleOrDefaultAsync();
            if (Registro != null && Registro.idArticulo > 0)
            {
                Registro.fechaCreacion = DateTime.Now;
                Registro.activo = false;
                return await conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<List<vArticulo>> GetVistaArticulos()
        {
            using var context = db.CreateDbContext();
            return await context.vArticulos
                .Where(a => a.activo)
                .ToListAsync();
        }
    }
}