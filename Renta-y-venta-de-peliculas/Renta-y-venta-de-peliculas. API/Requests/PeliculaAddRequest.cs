using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaAddRequest: PeliculaRequestbase
    {
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
