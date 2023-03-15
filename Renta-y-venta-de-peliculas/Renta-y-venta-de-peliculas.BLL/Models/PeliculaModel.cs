using System;

namespace Renta_y_venta_de_peliculas.BLL.Models
{
    public class PeliculaModel
    {
        public int CodPelicula { get; set; }
        public string TxtDesc { get; set; } = null!;
        public int Cant_Disponibles_Alquiler { get; set; }
        public int Cant_Disponibles_Venta { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateDisplay 
        {
            get { return this.CreateDate.ToString("dd/MM/yyyy"); }
        }
       
    } 
}

    

