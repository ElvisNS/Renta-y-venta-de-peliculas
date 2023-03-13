using Renta_y_venta_de_peliculas.DAL.Entities;
using System;
using System.Collections.Generic;
using Renta_y_venta_de_peliculas.DAL.Context;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Renta_y_venta_de_peliculas.DAL.Repositories
{
    public class AlquilerPeliculasRepository : Core.AlquilerPeliculaRepositoryBase<AlquilerPelicula>, Interfaces.IAlquilerPeliculasRepository
    {
        private readonly RYPContext rYPContext;
        private readonly ILogger<AlquilerPeliculasRepository> logger;

        public AlquilerPeliculasRepository(RYPContext rYPContext, ILogger<AlquilerPeliculasRepository> logger): base(rYPContext)
        {
            this.rYPContext = rYPContext;
            this.logger = logger;
        }

    }
}
