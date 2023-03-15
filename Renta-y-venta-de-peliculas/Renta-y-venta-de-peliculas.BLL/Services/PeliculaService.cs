using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;
using Renta_y_venta_de_peliculas.BLL.Models;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;


namespace Renta_y_venta_de_peliculas.BLL.Services
{
    public class PeliculaService : Contract.IPeliculaService
    {
        private readonly IPeliculaRepository peliculaRepository;
        private readonly ILogger<PeliculaService> logger;

        public PeliculaService(IPeliculaRepository peliculaRepository,
                               ILogger<PeliculaService> logger)
        {
            this.peliculaRepository = peliculaRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando las peliculas");

                var peliculas = this.peliculaRepository
                                    .GetEntities()
                                    .Select(pe => new PeliculaModel()
                                    {
                                        CodPelicula = pe.Cod_pelicula,
                                        Cant_Disponibles_Alquiler = pe.Cant_disponibles_alquiler,
                                        Cant_Disponibles_Venta = pe.Cant_disponibles_venta,
                                        TxtDesc = pe.Txt_desc,
                                        PrecioAlquiler = pe.Precio_alquiler,
                                        PrecioVenta = pe.Precio_venta,
                                        CreateDate = pe.Create_date
                                    }).ToList();

                result.Data = peliculas;

                this.logger.LogInformation("Se consultaron las peliculas")
            ; }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las peliculas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consultando la pelicula");

                var pelicula = this.peliculaRepository.GetEntity(Id);

                PeliculaModel peliculaModel = new PeliculaModel()
                {
                    CodPelicula = pelicula.Cod_pelicula,
                    Cant_Disponibles_Alquiler   = pelicula.Cant_disponibles_alquiler,
                    Cant_Disponibles_Venta= pelicula.Cant_disponibles_venta,
                    TxtDesc = pelicula.Txt_desc,
                    PrecioAlquiler = pelicula.Precio_alquiler,
                    PrecioVenta = pelicula.Precio_venta,
                    CreateDate= pelicula.Create_date
                };

                result.Data = peliculaModel;

                this.logger.LogInformation("Se consulto la pelicula");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las peliculas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemovePelicula(PeliculaRemoveDto peliculaRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Pelicula pelicula = this.peliculaRepository.GetEntity(peliculaRemove.CodPelicula);

                pelicula.Cod_pelicula = peliculaRemove.CodPelicula;
                pelicula.Deleted_date = peliculaRemove.Remove_date;
                pelicula.Deleted = true;
                pelicula.Deleted_user = peliculaRemove.Remove_user;

                this.peliculaRepository.Update(pelicula);
                this.peliculaRepository.SaveChanges();

                result.Message = "la pelicula fue removida correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error removiendo la pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
         }
        public ServiceResult SavePelicula(PeliculaAddDto peliculaAdd)
        {
                ServiceResult result= new ServiceResult();
            try
            {
                Pelicula pelicula = new Pelicula()
                {
                    Txt_desc = peliculaAdd.TxtDesc,
                    Create_date = peliculaAdd.CreateDate,
                    Create_user = peliculaAdd.CreateUser,
                    Precio_alquiler = peliculaAdd.PrecioAlquiler,
                    Precio_venta = peliculaAdd.PrecioVenta,
                    Cant_disponibles_alquiler = peliculaAdd.CantDisponiblesAlquiler,
                    Cant_disponibles_venta = peliculaAdd.CantDisponiblesVenta
                };

                this.peliculaRepository.Save(pelicula);
                this.peliculaRepository.SaveChanges();

                result.Message = " La pelicula fue guardado correctamente";
            }
             catch (Exception ex)
             {
                    result.Message = "Error guardando la pelicula";
                    result.Success = false;
                    this.logger.LogError($"{result.Message}", ex.ToString());
                }
                return result;
        }
        public ServiceResult UpdatePelicula(PeliculaUpdateDto peliculaUpdate)
        {

            ServiceResult result = new ServiceResult();
            try
            {
                Pelicula pelicula = this.peliculaRepository.GetEntity(peliculaUpdate.CodPelicula);

                pelicula.Cod_pelicula = peliculaUpdate.CodPelicula;
                pelicula.Txt_desc = peliculaUpdate.TxtDesc;
                pelicula.Modify_date = peliculaUpdate.ModifyDate;
                pelicula.Modify_user = peliculaUpdate.ModifyUser;
                pelicula.Precio_alquiler = peliculaUpdate.PrecioAlquiler;
                pelicula.Precio_venta = peliculaUpdate.PrecioVenta;
                pelicula.Cant_disponibles_alquiler = peliculaUpdate.CantDisponiblesAlquiler;
                pelicula.Cant_disponibles_venta = peliculaUpdate.CantDisponiblesVenta;
                
                this.peliculaRepository.Update(pelicula);
                this.peliculaRepository.SaveChanges();
                result.Message = "La pelicula fue modificada correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error guardando la pelicula";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
  }

