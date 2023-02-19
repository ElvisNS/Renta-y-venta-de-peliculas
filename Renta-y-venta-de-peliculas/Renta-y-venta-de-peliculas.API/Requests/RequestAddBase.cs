namespace Renta_y_venta_de_peliculas.API.Requests
{
    public abstract class RequestAddBase
    {
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}
