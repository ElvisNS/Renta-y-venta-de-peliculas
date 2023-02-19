using Renta_y_venta_de_peliculas.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Renta_y_venta_de_peliculas.DAL.Context
{
    public class RYPContext : DbContext
    {
        public RYPContext(DbContextOptions<RYPContext> options) : base(options)
        {

        }
        #region "Registro"
        public DbSet<User> user { get; set; }
        #endregion
    }
}
