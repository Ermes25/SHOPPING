using Microsoft.EntityFrameworkCore;
using SLCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Controllers
{
    public interface ICategoriaController
    {
        Task<List<Categoria>> GetCategorias();
        Task<int> Insert(Categoria Entidad);
        Task<bool> Update(Categoria Entidad);
        Task<bool> Delete(Categoria Entidad);
    }
    public class CategoriaController : ICategoriaController
    {
        readonly IDbContextFactory<dbContext> db;
        public CategoriaController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<Categoria>> GetCategorias()
        {
            using var context = db.CreateDbContext();
            return await context.Categorias.Where(a => a.activo).ToListAsync();
        }
        public async Task<int> Insert(Categoria Entidad)
        {
            using var context = db.CreateDbContext();
            context.Categorias.Add(Entidad);
            Entidad.activo = true;
            await context.SaveChangesAsync();
            return Entidad.idCategoria;
        }
        public async Task<bool> Update(Categoria Entidad)
        {
            using var context = db.CreateDbContext();
            context.Categorias.Update(Entidad);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Categoria Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.Categorias.Where(a => a.idCategoria == Entidad.idCategoria).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.activo = false;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
