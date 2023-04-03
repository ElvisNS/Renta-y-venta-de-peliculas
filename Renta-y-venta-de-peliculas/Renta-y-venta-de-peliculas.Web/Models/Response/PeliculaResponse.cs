namespace Renta_y_venta_de_peliculas.Web.Models.Response
{
    public class PeliculaResponse
    {
        public bool Success { get; set; }
        #nullable disable
        public PeliculaModel Data { get; set; }
        #nullable restore
        public string Message { get; set; } = string.Empty;

    }
}
