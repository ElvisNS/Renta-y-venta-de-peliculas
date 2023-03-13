using System;

namespace Renta_y_venta_de_peliculas.BLL.Models
{
    public class AlquilerPeliculaModel
    {
        public int Id { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public bool devuelta { get; set; }
        public DateTime? fecha_devolucion { get; set; }
        public int? cod_usuario_devolucion { get; set; }
        public DateTime CreateDate { get; set; }
        public string StartDateDisplay 
        { 
            get { return this.fecha.ToString("dd/MM/yyyy"); } 
        
        }
        public string CreateDateDisplay
        {
            get { return this.CreateDate.ToString("dd/MM/yyyy"); }

        }
    }
}
