using System;

namespace Renta_y_venta_de_pelicula.API.Requests
{
    public class AlquilerPeliculaRemoveRequest
    {
        public int? deleted_user { get; set; }
        public DateTime? deleted_date { get; set; }
        public bool deleted { get; set; }
    }
}
