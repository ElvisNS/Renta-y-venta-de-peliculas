using Renta_y_venta_de_peliculas.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renta_y_venta_de_peliculas.DAL.Interfaces
{
    public interface IPeliculaRepository
    {
        void Save(Pelicula pelicula);
        void Update(Pelicula pelicula);
        void Remove(Pelicula pelicula);
        Pelicula GetById(int peliculaId);
        List<Pelicula> GetAll();
        bool Exists(string desc);
    }
}
