
using Renta_y_venta_de_peliculas.DAL.Entities;
using System.Collections.Generic;

namespace Renta_y_venta_de_peliculas.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        void Remove(User user);
        User GetById(int userId);
        List<User> GetAll();
        bool Exists(string name);
    }
}
