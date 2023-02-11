namespace Renta_y_venta_de_peliculas.Web.Models
{
    public class VentaPeliculasModel
    {
        public int Id { get; set; }
        public int cod_pelicula { get; set; }
        public int  cod_usuario { get; set; }
        public decimal precio { get; set; } 
        public  DateTime fecha { get; set; }
    }
}
