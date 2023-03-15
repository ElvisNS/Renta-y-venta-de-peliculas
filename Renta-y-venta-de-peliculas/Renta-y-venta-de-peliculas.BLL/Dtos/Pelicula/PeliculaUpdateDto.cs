using System;

namespace Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula
{
    public class PeliculaUpdateDto
    {
        internal readonly DateTime Create_date;

        public int CodPelicula { get; set; }
        public string TxtDesc { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public int CantDisponiblesAlquiler { get; set; }
        public int CantDisponiblesVenta { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }
    }
}
