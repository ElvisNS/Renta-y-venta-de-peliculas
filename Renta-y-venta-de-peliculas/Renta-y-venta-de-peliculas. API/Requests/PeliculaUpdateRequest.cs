﻿using System;

namespace Renta_y_venta_de_peliculas._API.Requests
{
    public class PeliculaUpdateRequest : PeliculaAddRequestbase
    {
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}