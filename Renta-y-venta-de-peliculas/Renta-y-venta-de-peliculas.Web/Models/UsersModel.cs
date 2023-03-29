namespace Renta_y_venta_de_peliculas.Web.Models
{
    public class UsersModel
    {
        public int cod_usuario { get; set; }
        public string? txt_user { get; set; }    
        public string? txt_password { get; set; }
        public string? txt_nombre { get; set; }  
        public string? txt_apellido { get; set; }
        public string nro_doc { get; set; }
        public int cod_rol { get; set; }
        public int sn_activo { get; set; }
        public string creationDateDisplay { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(txt_nombre, " ", txt_apellido);
            }
        }
    }
}
