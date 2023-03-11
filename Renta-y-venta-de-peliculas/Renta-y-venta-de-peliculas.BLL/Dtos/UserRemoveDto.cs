using System;
using System.Collections.Generic;
using System.Text;

namespace Renta_y_venta_de_peliculas.BLL.Dtos
{
    public class UserRemoveDto 
    {
        public int cod_usuario { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
