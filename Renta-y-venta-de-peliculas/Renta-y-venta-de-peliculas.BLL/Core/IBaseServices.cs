
using Renta_y_venta_de_peliculas.BLL.Dtos;

namespace Renta_y_venta_de_peliculas.BLL.Core
{
    public interface IBaseServices
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);
        ServiceResult RemoveAlquilerPelicula(APelicualRemoveDto aPelicualRemove);
    }
}
