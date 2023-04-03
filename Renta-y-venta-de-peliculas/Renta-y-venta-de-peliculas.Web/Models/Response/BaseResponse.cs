namespace Renta_y_venta_de_peliculas.Web.Models.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        #nullable disable
        public dynamic Data { get; set; }
        #nullable restore
    }
}
