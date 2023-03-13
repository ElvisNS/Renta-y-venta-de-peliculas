using System;
using System.Collections.Generic;
using System.Text;

namespace Renta_y_venta_de_peliculas.BLL.Dtos
{
    public class APelicualAddDto
    {
        public int Id { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public bool devuelta { get; set; }
        public DateTime? fecha_devolucion { get; set; }
        public int? cod_usuario_devolucion { get; set; }
        public DateTime create_date { get; set; }
        public int create_user { get; set; }

    }
}
