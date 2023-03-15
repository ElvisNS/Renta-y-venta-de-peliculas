using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.DAL.Context;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Renta_y_venta_de_peliculas.DAL.Repositories
{
    public class PeliculaRepository : Core.RepositoryBase<Pelicula>, IPeliculaRepository
    {
        private readonly RYPContext rYPContext;
        private readonly ILogger<PeliculaRepository> logger;

        public PeliculaRepository(RYPContext rYPContext, ILogger<PeliculaRepository> logger) : base(rYPContext)
        {
            this.rYPContext = rYPContext;
            this.logger = logger;
        }
        public Pelicula GetPeliculaByCod(int cod_pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
