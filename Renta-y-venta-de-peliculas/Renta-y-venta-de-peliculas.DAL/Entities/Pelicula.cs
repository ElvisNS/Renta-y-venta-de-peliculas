using Renta_y_venta_de_peliculas.DAL.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renta_y_venta_de_peliculas.DAL.Entities
{
    [Table("tPeliculas", Schema = "dbo")]

    public class Pelicula : AuditEntity
    {
       [Key]
        public int Cod_pelicula { get; set; }
        public string Txt_desc { get; set; }
        public int Cant_disponibles_alquiler { get; set; }
        public int Cant_disponibles_venta { get; set; }
        public decimal Precio_alquiler { get; set; }
        public decimal Precio_venta { get; set; }
    }
}
