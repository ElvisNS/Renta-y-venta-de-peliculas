using Microsoft.EntityFrameworkCore;
using Renta_y_venta_de_peliculas.DAL.Entities;

namespace Renta_y_venta_de_peliculas.DAL.Context
{
    public class RYPContext : DbContext
    {
        public RYPContext(DbContextOptions<RYPContext>options) : base(options) 
        {

        }
        public DbSet<AlquilerPelicula>? alquilerpelicula { get; set; }
    }
}
