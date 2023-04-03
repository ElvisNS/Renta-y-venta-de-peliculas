﻿namespace Renta_y_venta_de_peliculas.Web.Models.Request
{
    public class PeliculaCreateRequest
    {
        public int codPelicula { get; set; }
        public string txtDesc { get; set; } = string.Empty;
        public decimal precioVenta { get; set; }
        public decimal precioAlquiler { get; set; }
        public int cantDisponiblesAlquiler { get; set; }
        public int cantDisponiblesVenta { get; set; }
        public DateTime createDate { get; set; }
        public int createUser { get; set; }
    }
}