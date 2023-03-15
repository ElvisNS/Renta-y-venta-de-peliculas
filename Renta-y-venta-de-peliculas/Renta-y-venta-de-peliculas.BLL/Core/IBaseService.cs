

using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;

namespace Renta_y_venta_de_peliculas.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
    }
}
