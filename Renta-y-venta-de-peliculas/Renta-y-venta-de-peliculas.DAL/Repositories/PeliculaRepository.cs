using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.DAL.Context;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Renta_y_venta_de_peliculas.DAL.Repositories
{
    public class PeliculaRepository :IPeliculaRepository
    {
        private readonly RYPContext rYPContext;
        private readonly ILogger<PeliculaRepository> ilogger;

        public PeliculaRepository(RYPContext rYPContext, ILogger<PeliculaRepository> ilogger)
        {
            this.rYPContext = rYPContext;
            this.ilogger = ilogger;
        }
        public bool Exists(string desc)
        {
            return this.rYPContext.Peliculas.Any(st => st.Txt_desc == desc);
        }

        public List<Pelicula> GetAll()
        {
            return this.rYPContext.Peliculas.Where(Pelicula=> !Pelicula.Deleted).ToList();
        }

        public Pelicula GetById(int cod_pelicula)
        {
            return this.rYPContext.Peliculas.Find(cod_pelicula);
        }

        public void Remove(Pelicula pelicula)
        {
            try
            {
                Pelicula peliculaToRemove = this.GetById(pelicula.Cod_pelicula); ;
                peliculaToRemove.Deleted_date = pelicula.Deleted_date;
                peliculaToRemove.Deleted_user = pelicula.Deleted_user;
                peliculaToRemove.Deleted= true;

                this.rYPContext.Peliculas.Update(peliculaToRemove);
                this.rYPContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error removiendo la pelicula", ex.ToString());
            }
        }

        public void Save(Pelicula pelicula)
        {
            try
            {
                Pelicula peliculaToAdd = new Pelicula()
                {
                    Txt_desc = pelicula.Txt_desc,
                    Cant_disponibles_alquiler = pelicula.Cant_disponibles_alquiler,
                    Cant_disponibles_venta = pelicula.Cant_disponibles_venta,
                    Precio_alquiler = pelicula.Precio_alquiler,
                    Precio_venta = pelicula.Precio_venta,
                    Create_date =pelicula.Create_date,
                    Create_user= pelicula.Create_user
                };


                this.rYPContext.Peliculas.Add(peliculaToAdd);
                this.rYPContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error guardando la pelicula {ex.Message}", ex.ToString());
            }
        }

        public void Update(Pelicula pelicula)
        {
            try
            {
                Pelicula peliculaToUpdate = this.GetById(pelicula.Cod_pelicula);
               
                
                peliculaToUpdate.Txt_desc = pelicula.Txt_desc;
                peliculaToUpdate.Cant_disponibles_alquiler = pelicula.Cant_disponibles_alquiler;
                peliculaToUpdate.Cant_disponibles_venta= pelicula.Cant_disponibles_venta;
                peliculaToUpdate.Precio_venta= pelicula.Precio_venta;
                peliculaToUpdate.Precio_alquiler= pelicula.Precio_alquiler;
                peliculaToUpdate.Modify_date = pelicula.Modify_date;
                peliculaToUpdate.Modify_user = pelicula.Modify_user;


                this.rYPContext.Peliculas.Update(peliculaToUpdate);
                this.rYPContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error actualizando la pelicula { ex.Message } ", ex.ToString());
            }
        }
    }
}
