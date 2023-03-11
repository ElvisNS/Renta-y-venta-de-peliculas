using Microsoft.Extensions.DependencyInjection;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Services;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using Renta_y_venta_de_peliculas.DAL.Repositories;

namespace Renta_y_venta_de_pelicula.API.Dependencies
{
    public static class UserDependency
    {
        public static void AddUserDependency(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
