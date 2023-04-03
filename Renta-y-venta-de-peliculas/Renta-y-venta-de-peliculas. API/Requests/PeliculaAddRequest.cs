using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaAddDto: PeliculaAddRequestbase
    {
        public int Create_user { get; set; }
        public DateTime Create_date { get; set; }
    }
}
