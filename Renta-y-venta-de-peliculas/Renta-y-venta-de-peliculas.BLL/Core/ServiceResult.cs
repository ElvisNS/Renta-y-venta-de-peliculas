

namespace Renta_y_venta_de_peliculas.BLL.Core
{
    public class ServiceResult
    {
        public ServiceResult() 
        {
            this.Success = true;
        }

        public bool Success { get; set; } 
        public string Message { get; set; } = string.Empty;
        public dynamic Data { get; set; } = string.Empty ;

    }
}
