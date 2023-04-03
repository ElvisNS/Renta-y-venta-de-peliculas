using System;

namespace Renta_y_venta_de_peliculas.BLL.Models
{
    public class PeliculaResultModel
    {
        public int codPelicula { get; set; }
        public string txtDesc { get; set; } = string.Empty;
        public int cant_Disponibles_Alquiler { get; set; }
        public int cant_Disponibles_Venta { get; set; }
        public decimal precioVenta { get; set; }
        public decimal precioAlquiler { get; set; }
        public decimal PrecioAlquiler { get; internal set; }
        public DateTime createDate { get; set; }
        public string createDateDisplay 
        {
            get { return this.createDate.ToString("dd/MM/yyyy"); }
        }
       
    } 
}

    

