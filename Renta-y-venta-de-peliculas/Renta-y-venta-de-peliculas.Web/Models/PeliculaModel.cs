namespace Renta_y_venta_de_peliculas.Web.Models
{
    public class PeliculaModel
    {
        public int codPelicula { get; set; }
        public string txtDesc { get; set; }
        public int cant_Disponibles_Alquiler { get; set; }
        public int cant_Disponibles_Venta { get; set; }
        public double precioVenta { get; set; }
        public double precioAlquiler { get; set; }
        public DateTime createDate { get; set; }
        public string createDateDisplay { get; set; }



    }
}
