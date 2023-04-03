namespace Renta_y_venta_de_peliculas.Web.Models.Response
{
    public class PeliculaListResponse
    {
        public bool Success { get; set; }
        #nullable disable
        public List<PeliculaModel> Data { get; set; }
        #nullable restore
        public string Message { get; set; } = string.Empty;
        


    }
}