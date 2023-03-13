using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos;
using Renta_y_venta_de_peliculas.BLL.Models;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;


namespace Renta_y_venta_de_peliculas.BLL.Services
{
    public class AlquilerPeliculaService : IAPeliculasService
    {
        private readonly IAlquilerPeliculasRepository alquilerPeliculasRepository;
        private readonly ILogger<AlquilerPeliculaService> logger;

        public AlquilerPeliculaService(IAlquilerPeliculasRepository alquilerPeliculasRepository, ILogger<AlquilerPeliculaService> logger)
        {
            this.alquilerPeliculasRepository = alquilerPeliculasRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consultando los alquileres de peliculas");

                var alquilerpelicula = this.alquilerPeliculasRepository
                                           .GetEntities()
                                           .Select(alq => new AlquilerPeliculaModel()
                                           {
                                                Id= alq.Id,
                                                precio = alq.precio,
                                                fecha = alq.fecha,
                                                cod_pelicula= alq.cod_pelicula,
                                                cod_usuario= alq.cod_usuario,
                                                devuelta= alq.devuelta,
                                                fecha_devolucion = alq.fecha_devolucion,
                                                cod_usuario_devolucion = alq.cod_usuario_devolucion,
                                                CreateDate = alq.fecha
                                           }).ToList();
                result.Data = alquilerpelicula;

                this.logger.LogInformation("se consultaron los alquileres de peliculas");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo alquiler peliculas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consultando rl alquiler pelicula");

                var alquilerpelicula = this.alquilerPeliculasRepository.GetEntity(Id);

                AlquilerPeliculaModel alquilerPeliculaModel = new AlquilerPeliculaModel() 
                {
                    Id = alquilerpelicula.Id,
                    precio = alquilerpelicula.precio,
                    fecha = alquilerpelicula.fecha,
                    cod_pelicula = alquilerpelicula.cod_pelicula,
                    cod_usuario = alquilerpelicula.cod_usuario,
                    devuelta = alquilerpelicula.devuelta,
                    fecha_devolucion = alquilerpelicula.fecha_devolucion,
                    cod_usuario_devolucion = alquilerpelicula.cod_usuario_devolucion,
                    CreateDate = alquilerpelicula.fecha
                };

                result.Data = alquilerPeliculaModel;

                this.logger.LogInformation("se consultaró el alquiler pelicula");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el alquiler pelicula";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveAlquilerPelicula(APelicualRemoveDto AlqPeliculaRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.AlquilerPelicula alquilerPelicula = this.alquilerPeliculasRepository.GetEntity(AlqPeliculaRemove.Id);

                alquilerPelicula.Id = AlqPeliculaRemove.Id;
                alquilerPelicula.deleted_date = AlqPeliculaRemove.RemoveDate;
                alquilerPelicula.deleted = true;
                alquilerPelicula.deleted_user = AlqPeliculaRemove.RemoveUser;

                this.alquilerPeliculasRepository.Update(alquilerPelicula);
                this.alquilerPeliculasRepository.SaveChanges();

                result.Message = "El Alquiler Pelicula fue removido correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error removiendo el Alquiler Pelicula";
                result.Success=false;
                this.logger.LogError($" {result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveAlquilerPelicula(APelicualAddDto aPelicualAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                AlquilerPelicula AlquiPelicula = new AlquilerPelicula()
                {
                    Id = aPelicualAddDto.Id,
                    precio = aPelicualAddDto.precio,
                    fecha = aPelicualAddDto.fecha,
                    cod_pelicula = aPelicualAddDto.cod_pelicula,
                    cod_usuario = aPelicualAddDto.cod_usuario,
                    devuelta = aPelicualAddDto.devuelta,
                    fecha_devolucion = aPelicualAddDto.fecha_devolucion,
                    cod_usuario_devolucion = aPelicualAddDto.cod_usuario_devolucion,
                    create_date = aPelicualAddDto.create_date,
                    create_user = aPelicualAddDto.create_user
                   
                };
                this.alquilerPeliculasRepository.Save(AlquiPelicula);
                this.alquilerPeliculasRepository.SaveChanges();

                result.Message = "El Alquiler Pelicula fue guardado correctamente.";
            }
            catch (Exception ex) 
            {

                result.Message = "Error guardando el Alquiler Pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateAlquilerPelicula(APeliculaUpdateDto aPeliculaUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                AlquilerPelicula? AlquiPelicula = this.alquilerPeliculasRepository.GetEntity(aPeliculaUpdateDto.Id);

                AlquiPelicula.Id = aPeliculaUpdateDto.Id;
                AlquiPelicula.precio = aPeliculaUpdateDto.precio;
                AlquiPelicula.modify_date = aPeliculaUpdateDto.fecha;
                AlquiPelicula.cod_pelicula = aPeliculaUpdateDto.cod_pelicula;
                AlquiPelicula.cod_usuario = aPeliculaUpdateDto.cod_usuario;
                AlquiPelicula.fecha_devolucion = aPeliculaUpdateDto.fecha_devolucion;
                AlquiPelicula.cod_usuario_devolucion = aPeliculaUpdateDto.cod_usuario_devolucion;
                AlquiPelicula.modify_user = aPeliculaUpdateDto.modify_user;
                

                
                this.alquilerPeliculasRepository.Update(AlquiPelicula);
                this.alquilerPeliculasRepository.SaveChanges();


                result.Message = "El Alquiler Pelicula fue modificado correctamente.";
            }
            catch (Exception ex)
            {

                result.Message = "Error guardando el Alquiler Pelicula";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}
