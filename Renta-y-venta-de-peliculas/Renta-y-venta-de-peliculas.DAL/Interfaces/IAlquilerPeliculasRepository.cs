using Renta_y_venta_de_peliculas.DAL.Entities;

namespace Renta_y_venta_de_peliculas.DAL.Interfaces
{
    public interface IAlquilerPeliculasRepository : Core.IRepositoryBase<AlquilerPelicula>
    {
        void SaveChanges();
    }
}
