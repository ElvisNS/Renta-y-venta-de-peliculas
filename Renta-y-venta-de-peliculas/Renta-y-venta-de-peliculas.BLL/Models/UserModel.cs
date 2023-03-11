
using System;

namespace Renta_y_venta_de_peliculas.BLL.Models
{
    public class UserModel
    {
        public int cod_usuario { get; set; }
        public string? txt_user { get; set; }
        public string? txt_password { get; set; }
        public string? txt_nombre { get; set; }
        public string? txt_apellido { get; set; }
        public string? nro_doc { get; set; }
        public int? sn_activo { get; set; }
        public int? cod_rol { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationDateDisplay
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }

        }
    }
}
