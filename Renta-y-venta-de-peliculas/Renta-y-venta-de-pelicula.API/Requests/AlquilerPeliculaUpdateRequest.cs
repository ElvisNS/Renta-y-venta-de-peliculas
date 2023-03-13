using System;

namespace Renta_y_venta_de_pelicula.API.Requests
{
    public class AlquilerPeliculaUpdateRequest : AlquilerPeliculaRequestBase
    {
        public int? modify_user { get; set; }
        public DateTime? modify_date { get; set; }
        public int Id { get; set; }
    }
}
