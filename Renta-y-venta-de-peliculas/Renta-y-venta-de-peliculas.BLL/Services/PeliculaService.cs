using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;
using Renta_y_venta_de_peliculas.BLL.Models;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using Renta_y_venta_de_peliculas.BLL.Extensions;
using Renta_y_venta_de_peliculas.BLL.Exceptions;


namespace Renta_y_venta_de_peliculas.BLL.Services
{
    public class PeliculaService : IPeliculaService
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
                var peliculas = this.peliculaRepository.GetEntities().Select(cd => new PeliculaResultModel()

                {
                    codPelicula = cd.Cod_pelicula,
                    cant_Disponibles_Alquiler = cd.Cant_disponibles_alquiler,
                    cant_Disponibles_Venta = cd.Cant_disponibles_venta,
                    txtDesc = cd.Txt_desc,
                    precioAlquiler = cd.Precio_alquiler,
                    precioVenta = cd.Precio_venta,
                    createDate = cd.Create_date

                }).ToList();

                result.Data = peliculas;
                result.Success = true;
               
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las peliculas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
           
            try
            {
                var pelicula = this.peliculaRepository.GetEntity(Id);

                PeliculaResultModel peliculaResultModel = new PeliculaResultModel()
                {
                 codPelicula = pelicula.Cod_pelicula,
                 cant_Disponibles_Alquiler = pelicula.Cant_disponibles_alquiler,
                 cant_Disponibles_Venta = pelicula.Cant_disponibles_venta,
                 txtDesc = pelicula.Txt_desc,
                 PrecioAlquiler = pelicula.Precio_alquiler,
                 precioVenta = pelicula.Precio_venta,
                 createDate = pelicula.Create_date

            };
                
                result.Data = peliculaResultModel;
                result.Success = true;
                               
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las peliculas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemovePelicula(PeliculaRemoveDto removeDto)
        {
            
            ServiceResult result = new ServiceResult();
            try
            {
                Pelicula peliculaToRemove = this.peliculaRepository.GetEntity(removeDto.codPelicula);
              
                peliculaToRemove.Deleted = removeDto.removed;
                peliculaToRemove.Deleted_date  = removeDto.remove_date;
                peliculaToRemove.Deleted_user = removeDto.remove_user;

                this.peliculaRepository.Update(peliculaToRemove);

                result.Success=true;
                result.Message = "la pelicula ha sido eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo la pelicula";
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
         }
        public ServiceResult SavePelicula(PeliculaSaveDto saveDto)
        {
            this.logger.LogInformation("Paso por aqui", saveDto.txtDesc);
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(saveDto.txtDesc))

            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (saveDto.txtDesc.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es inválida";
                return result;
            }

            try
            {
                Pelicula pelicula = saveDto.GetPeliculaEntityFromDtoSave();
                this.peliculaRepository.Save(pelicula);
                result.Success = true;
                result.Message = "La pelicula ha sido agregada correctamente.";

                this.logger.LogInformation(result.Message, result);
            }
            catch (PeliculaDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, sdex.ToString());
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error agregando la pelicula";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;

        }

        public ServiceResult UpdatePelicula(PeliculaUpdateDto updateDto)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                if (string.IsNullOrEmpty(updateDto.txtDesc))

                {
                    result.Success = false;
                    result.Message = "El nombre es requerido";
                    return result;
                }

                if (updateDto.txtDesc.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La longitud del nombre es inválida";
                    return result;
                }

                Pelicula pelicula = this.peliculaRepository.GetEntity(updateDto.codPelicula);
                pelicula.Txt_desc = updateDto.txtDesc;
                pelicula.Modify_date = updateDto.modifyDate;
                pelicula.Modify_user = updateDto.modifyUser;
                pelicula.Cant_disponibles_alquiler = updateDto.cantDisponiblesAlquiler;
                pelicula.Cant_disponibles_venta = updateDto.cantDisponiblesVenta;
                pelicula.Precio_alquiler = updateDto.precioAlquiler;
                pelicula.Precio_venta = updateDto.precioVenta;

                this.peliculaRepository.Update(pelicula);
                result.Success = true;
                result.Message = "La pelicula ha sido actualizado correctamente.";

            }
            catch (PeliculaDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, sdex.ToString());
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el estudiante";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
 
        }
    }
  }

