using Microsoft.EntityFrameworkCore;
using SLCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Controllers
{
    public interface IControlacController
    {
        Task<List<vControlac>> GetControlacs();
    }
    public class ControlacController : IControlacController
    {
        readonly IDbContextFactory<dbContext> db;

        // Constructor que inyecta el contexto de la base de datos
        public ControlacController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<vControlac>> GetControlacs()
        {
            using var context = db.CreateDbContext();
            return await context.vControlacs.ToListAsync();  // Consulta la vista y la devuelve como lista
        }

    }
}
