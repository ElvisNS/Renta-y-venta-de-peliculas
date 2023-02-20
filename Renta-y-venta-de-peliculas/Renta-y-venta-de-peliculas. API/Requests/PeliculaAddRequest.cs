using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaAddRequest: PeliculaAddRequestbase
    {
        public int Create_user { get; set; }
        public DateTime Create_date { get; set; }
    }
}
