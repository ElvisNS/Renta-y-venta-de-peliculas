using System;

namespace Renta_y_venta_de_pelicula.API.Requests
{
    public class UserUpdateRequest : UserRequestBase
    {
        public int cod_usuario { get; set; }
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
