﻿namespace Renta_y_venta_de_peliculas.Web.Models.Request
{
    public class UserUpdateRequest
    {
        public string txt_user { get; set; }
        public string txt_password { get; set; }
        public string txt_nombre { get; set; }
        public string txt_apellido { get; set; }
        public string nro_doc { get; set; }
        public int cod_rol { get; set; }
        public int sn_activo { get; set; }
        public int cod_usuario { get; set; }
        public int userMod { get; set; }
        public DateTime modifyDate { get; set; }
    }
}