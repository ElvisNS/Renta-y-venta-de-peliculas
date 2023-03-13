using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Renta_y_venta_de_peliculas.DAL.Entities
{
    [Table("tAlquilerPeliculas", Schema = "dbo")]
    public class AlquilerPelicula : Core.AuditEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public bool devuelta { get; set; }
        public DateTime? fecha_devolucion { get; set; }
        public int? cod_usuario_devolucion { get; set; }
    }
}
