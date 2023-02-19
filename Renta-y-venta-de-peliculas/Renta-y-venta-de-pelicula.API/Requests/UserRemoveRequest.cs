using System;

namespace Renta_y_venta_de_pelicula.API.Requests
{
    public class UserRemoveRequest
    {
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
