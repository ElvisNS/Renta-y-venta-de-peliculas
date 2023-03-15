using System;

namespace Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula
{
    public class PeliculaRemoveDto
    {
        public int CodPelicula { get; set; }
        public int Remove_user { get; set; }
        public DateTime Remove_date { get; set; }
    }
}
