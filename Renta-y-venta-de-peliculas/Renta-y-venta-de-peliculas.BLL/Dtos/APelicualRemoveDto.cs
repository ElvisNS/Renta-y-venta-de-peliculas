using System;

namespace Renta_y_venta_de_peliculas.BLL.Dtos
{
    public class APelicualRemoveDto
    {
        public int Id { get; set; }
        public DateTime? RemoveDate { get; set; }
        public int? RemoveUser { get; set; }
    }
}
