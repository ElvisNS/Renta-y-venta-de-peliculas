namespace Renta_y_venta_de_peliculas.Web.Models.Response
{
    public class UserListResponse
    {
        public bool sucess { get; set; }
        public List<UsersModel> data { get; set; }
        public string message { get; set; }
    }
}
