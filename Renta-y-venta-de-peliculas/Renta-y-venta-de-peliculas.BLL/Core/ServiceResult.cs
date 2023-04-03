

namespace Renta_y_venta_de_peliculas.BLL.Core
{
    public class ServiceResult
    {
#nullable disable
        public ServiceResult()
        {
            this.Success = false;
        }
#nullable restore

        public bool Success { get; set; } 
        public string Message { get; set; } 
        public dynamic Data { get; set; } 

    }
}
