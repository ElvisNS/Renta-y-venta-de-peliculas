using System;
using System.Collections.Generic;
using System.Text;

namespace Renta_y_venta_de_peliculas.BLL.Dtos
{
    public class UserAddDto : UserBaseDto
    {
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
