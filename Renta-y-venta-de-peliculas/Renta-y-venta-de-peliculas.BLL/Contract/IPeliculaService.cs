using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;

namespace Renta_y_venta_de_peliculas.BLL.Contract
{
   public interface IPeliculaService : IBaseService 
    {
        ServiceResult SavePelicula(PeliculaSaveDto saveDto);
        ServiceResult UpdatePelicula(PeliculaUpdateDto updateDto);
        ServiceResult RemovePelicula(PeliculaRemoveDto removeDto);

    }
}
