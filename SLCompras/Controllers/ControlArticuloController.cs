using Microsoft.EntityFrameworkCore;
using SLCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCompras.Controllers
{
    public interface IcontrolArticuloController
    {
        Task<List<vControlArticulo>> GetControlarticulos();
        Task<decimal> GetTotalPrecio();
        Task<int> GetTotalCantidad();
    }
    public class ControlArticuloController : IcontrolArticuloController
    {
        readonly IDbContextFactory<dbContext> db;

        // Constructor que inyecta el contexto de la base de datos
        public ControlArticuloController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<vControlArticulo>> GetControlarticulos()
        {
            using var context = db.CreateDbContext();
            return await context.vControlArticulos.ToListAsync();  // Consulta la vista y la devuelve como lista
        }
        // Nuevo método para obtener el total de los PrecioTotal
        public async Task<decimal> GetTotalPrecio()
        {
            using var context = db.CreateDbContext();

            // Sumar los valores de PrecioTotal
            var totalPrecio = await context.vControlArticulos
                                          .Where(a => a.PrecioTotal > 0)  // Puedes agregar un filtro si es necesario
                                          .SumAsync(a => a.PrecioTotal); // Suma de los PrecioTotal

            return totalPrecio;
        }
        // Método para obtener el total de las cantidades de artículos
        public async Task<int> GetTotalCantidad()
        {
            using var context = db.CreateDbContext();

            // Sumar las cantidades de los artículos
            var totalCantidad = await context.vControlArticulos
                                             .Where(a => a.cantidad > 0)  // Puedes agregar un filtro si es necesario
                                             .SumAsync(a => a.cantidad);  // Suma de las cantidades

            return totalCantidad;
        }

    }
}
