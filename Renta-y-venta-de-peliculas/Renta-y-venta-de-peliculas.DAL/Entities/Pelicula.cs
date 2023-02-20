using Renta_y_venta_de_peliculas.DAL.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renta_y_venta_de_peliculas.DAL.Entities
{
    [Table("tPeliculas", Schema = "dbo")]

    public class Pelicula : Core.AuditEntity
    {
       [Key]
        public int cod_pelicula { get; set; }
        public string? txt_desc { get; set; }
        public int cant_disponibles_alquiler { get; set; }
        public int cant_disponibles_venta { get; set; }
        public decimal precio_alquiler { get; set; }
        public decimal precio_venta { get; set; }
    }
}
