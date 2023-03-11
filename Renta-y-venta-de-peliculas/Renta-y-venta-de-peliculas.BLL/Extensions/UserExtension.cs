using Renta_y_venta_de_peliculas.BLL.Dtos;
using Renta_y_venta_de_peliculas.DAL.Entities;

namespace Renta_y_venta_de_peliculas.BLL.Extensions
{
    public static class UserExtension
    {
        public static User GetUserEntityFromDtoSave(this UserAddDto userAdd)
        {
            User user = new User()
            {
                txt_user = userAdd.txt_user,
                txt_password = userAdd.txt_password,
                txt_nombre = userAdd.txt_nombre,
                txt_apellido = userAdd.txt_apellido,
                nro_doc = userAdd.nro_doc,
                sn_activo = userAdd.sn_activo,
                cod_rol = userAdd.cod_rol,
                CreationUser = userAdd.CreationUser,
                CreationDate = userAdd.CreationDate
            };
            return user;
        }
    }
}
