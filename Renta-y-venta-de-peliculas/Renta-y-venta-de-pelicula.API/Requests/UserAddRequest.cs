using System;

namespace Renta_y_venta_de_pelicula.API.Requests
{
    public class UserAddRequest : UserRequestBase
    {
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
