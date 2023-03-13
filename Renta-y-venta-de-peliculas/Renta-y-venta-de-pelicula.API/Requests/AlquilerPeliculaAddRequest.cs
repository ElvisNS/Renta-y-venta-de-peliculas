using System;

namespace Renta_y_venta_de_pelicula.API.Requests
{
    public class AlquilerPeliculaAddRequest : AlquilerPeliculaRequestBase
    {
        public int create_user { get; set; }
        public DateTime create_date { get; set; }
    }
}
