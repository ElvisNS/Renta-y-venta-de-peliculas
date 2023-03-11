using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renta_y_venta_de_peliculas.DAL.Entities
{
    [Table("tUsers", Schema ="dbo")]
    public class User : Core.AuditEntity
    {
        [Key]
        public int cod_usuario { get; set; }
        public string? txt_user { get; set; }
        public string? txt_password { get; set; }
        public string? txt_nombre { get; set; }
        public string? txt_apellido { get; set; }
        public string? nro_doc { get; set; }
        public int? cod_rol { get; set; }
        public int? sn_activo { get; set; }
    }
}
