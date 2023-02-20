using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.DAL.Context;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renta_y_venta_de_peliculas.DAL.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
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
            return this.rYPContext.pelicula.Any(st => st.txt_desc == desc);
        }

        public List<Pelicula> GetAll()
        {
            return this.rYPContext.pelicula.Where(pe => !pe.Deleted).ToList();
        }

        public Pelicula GetById(int peliculaId)
        {
            return this.rYPContext.pelicula.Find(peliculaId);
        }

        public void Remove(Pelicula pelicula)
        {
            try
            {
                Pelicula peliculaToRemove = this.GetById(pelicula.cod_pelicula); ;
                peliculaToRemove.DeletedDate = DateTime.Now;
                peliculaToRemove.UserDeleted = pelicula.UserDeleted;
                peliculaToRemove.Deleted = true;

                this.rYPContext.pelicula.Update(peliculaToRemove);
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
                    txt_desc = pelicula.txt_desc,
                    cant_disponibles_alquiler = pelicula.cant_disponibles_alquiler,
                    cant_disponibles_venta = pelicula.cant_disponibles_venta,
                    precio_alquiler = pelicula.precio_alquiler,
                    precio_venta = pelicula.precio_venta,
                    CreationDate = DateTime.Now,
                    CreationUser = pelicula.CreationUser
                };


                this.rYPContext.pelicula.Add(peliculaToAdd);
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
                Pelicula peliculaToUpdate = this.GetById(pelicula.cod_pelicula);
               
                peliculaToUpdate.txt_desc = pelicula.txt_desc;
                peliculaToUpdate.cant_disponibles_alquiler = pelicula.cant_disponibles_alquiler;
                peliculaToUpdate.cant_disponibles_venta= pelicula.cant_disponibles_venta;
                peliculaToUpdate.precio_venta= pelicula.precio_venta;
                peliculaToUpdate.precio_alquiler= pelicula.precio_alquiler;
                peliculaToUpdate.ModifyDate = DateTime.Now;
                peliculaToUpdate.UserMod = pelicula.UserMod;


                this.rYPContext.pelicula.Update(peliculaToUpdate);
                this.rYPContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error actualizando la pelicula { ex.Message } ", ex.ToString());
            }
        }
    }
}
