using System;
using System.Collections.Generic;
using System.Text;

namespace Renta_y_venta_de_peliculas.BLL.Dtos
{
    public class UserUpdateDto : UserBaseDto
    {
        public int cod_usuario { get; set; }
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
