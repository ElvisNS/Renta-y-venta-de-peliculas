using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;

namespace Renta_y_venta_de_peliculas.BLL.Contract
{
   public interface IPeliculaService : IBaseService 
    {
        ServiceResult SavePelicula(PeliculaAddDto peliculaAdd);
        ServiceResult UpdatePelicula(PeliculaUpdateDto peliculaUpdate);
        ServiceResult RemovePelicula(PeliculaRemoveDto peliculaRemove);

    }
}
