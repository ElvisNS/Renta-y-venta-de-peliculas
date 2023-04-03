using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;
using Renta_y_venta_de_peliculas.DAL.Entities;

namespace Renta_y_venta_de_peliculas.BLL.Extensions
{
    public static class PeliculaExtension
    {
        public static Pelicula GetPeliculaEntityFromDtoSave(this PeliculaSaveDto saveDto)
        {
            Pelicula pelicula = new Pelicula()
            {
                Txt_desc = saveDto.txtDesc,
                Precio_venta = saveDto.precioVenta,
                Precio_alquiler = saveDto.precioAlquiler,
                Cant_disponibles_alquiler = saveDto.cantDisponiblesAlquiler,
                Cant_disponibles_venta = saveDto.cantDisponiblesVenta,
                Create_date = saveDto.createDate,
                Create_user = saveDto.createUser
            };
            return pelicula;
        }
    }
}



    
        
            
            
            

