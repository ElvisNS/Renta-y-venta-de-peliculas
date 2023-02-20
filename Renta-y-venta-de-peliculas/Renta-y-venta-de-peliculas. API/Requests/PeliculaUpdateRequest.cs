using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaUpdateRequest : PeliculaRequestbase
    {
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
