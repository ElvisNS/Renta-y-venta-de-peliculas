using Renta_y_venta_de_peliculas.DAL.Entities;
using System.Collections.Generic;

namespace Renta_y_venta_de_peliculas.DAL.Interfaces
{
    public interface IPeliculaRepository
    {
        void Save(Pelicula pelicula);
        void Update(Pelicula pelicula);
        void Remove(Pelicula pelicula);
        Pelicula GetById(int cod_pelicula);
        List<Pelicula> GetAll();
        bool Exists(string desc);
    }
}
