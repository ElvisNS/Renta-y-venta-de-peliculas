using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public abstract class PeliculaAddRequestbase
    {
        public int Cod_pelicula { get; set; }
        public string Txt_desc { get; set; }
        public int Cant_disponibles_alquiler { get; set; }
        public int Cant_disponibles_venta { get; set; }
        public decimal Precio_alquiler { get; set; }
        public decimal Precio_venta { get; set; }
       
    }
}
