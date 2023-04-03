using System;

namespace Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula
{
    public class PeliculaUpdateDto
    {
        public int codPelicula { get; set; }
        public string txtDesc { get; set; } = string.Empty;
        public decimal precioVenta { get; set; }
        public decimal precioAlquiler { get; set; }
        public int cantDisponiblesAlquiler { get; set; }
        public int cantDisponiblesVenta { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
