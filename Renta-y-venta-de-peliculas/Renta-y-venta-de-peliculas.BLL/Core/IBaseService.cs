
namespace Renta_y_venta_de_peliculas.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);
    }
}
