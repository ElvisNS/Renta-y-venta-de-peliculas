using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos;

namespace Renta_y_venta_de_peliculas.BLL.Contract
{
    public interface IAPeliculasService : IBaseServices
    {
        ServiceResult SaveAlquilerPelicula(APelicualAddDto aPelicualAddDto);
        ServiceResult UpdateAlquilerPelicula(APeliculaUpdateDto aPeliculaUpdateDto);
        ServiceResult RemoveAlquilerPelicula(APelicualRemoveDto aPelicualRemoveDto);
    }
}
