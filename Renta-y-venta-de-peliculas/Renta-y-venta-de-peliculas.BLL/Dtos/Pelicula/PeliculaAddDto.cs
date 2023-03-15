using System;

namespace Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula
{
    public class PeliculaAddDto
    {
        public string TxtDesc { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public int CantDisponiblesAlquiler { get; set; }
        public int CantDisponiblesVenta { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}
