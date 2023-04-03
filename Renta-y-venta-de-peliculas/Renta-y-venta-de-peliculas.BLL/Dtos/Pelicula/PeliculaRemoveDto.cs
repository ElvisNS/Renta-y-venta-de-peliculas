using System;

namespace Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula
{
    public class PeliculaRemoveDto
    {
        public int codPelicula { get; set; }
        public int remove_user { get; set; }
        public DateTime remove_date { get; set; }
        public bool removed { get; set; }
    }
}
