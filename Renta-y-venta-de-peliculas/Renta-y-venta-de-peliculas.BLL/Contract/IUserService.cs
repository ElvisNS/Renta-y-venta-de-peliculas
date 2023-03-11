using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos;

namespace Renta_y_venta_de_peliculas.BLL.Contract
{
    public interface IUserService : IBaseService
    {
        ServiceResult SaveUser(UserAddDto userAddDto);
        ServiceResult UpdateUser(UserUpdateDto userUpdateDto);
        ServiceResult RemoveUser(UserRemoveDto userRemoveDto);
    }
}
