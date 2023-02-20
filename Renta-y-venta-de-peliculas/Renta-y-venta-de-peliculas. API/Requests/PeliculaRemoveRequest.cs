using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaRemoveRequest
    {
        public int? Deleted_user { get; set; }
        public DateTime? Deleted_date { get; set; }
        public bool Deleted { get; set; }
    }
}
