using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.Models.Response;

namespace Renta_y_venta_de_peliculas.Web.APIservices.Interfaces
{
    public interface IPeliculaApiService
    {
        Task<PeliculaListResponse> GetPeliculas();
        Task<PeliculaResponse> GetPelicula(int id);
        Task<BaseResponse> Update(PeliculaUpdateRequest peliculaModel);
        Task<BaseResponse> Save(PeliculaCreateRequest peliculaModel);
    }
}
