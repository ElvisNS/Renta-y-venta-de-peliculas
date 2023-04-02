using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.Models.Response;

namespace Renta_y_venta_de_peliculas.Web.APIServices.Interfaces
{
    public interface IUserApiService
    {
        Task<UserListResponse> GetUsers();
        Task<UserResponse> GetUser(int Id);
        Task<BaseResponse> Update(UserUpdateRequest userUpdateRequest);
        Task<BaseResponse> Save(UserCreateRequest userCreateRequest);
    }
}
