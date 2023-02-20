using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaRemoveRequest
    {
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
