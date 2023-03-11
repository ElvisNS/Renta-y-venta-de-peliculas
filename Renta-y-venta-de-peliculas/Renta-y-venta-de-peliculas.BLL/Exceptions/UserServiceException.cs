using System;

namespace Renta_y_venta_de_peliculas.BLL.Exceptions
{
    public class UserServiceException : Exception
    {
        public UserServiceException(string message) : base(message) 
        {
            //Aqui deberia ir logica//
        }
    }
}
