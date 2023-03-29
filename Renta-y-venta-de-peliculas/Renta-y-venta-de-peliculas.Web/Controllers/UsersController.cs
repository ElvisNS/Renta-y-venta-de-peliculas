using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.Models.Response;
using System.Text;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class UsersController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<UsersController> logger;
        private readonly IConfiguration configuration;

        public UsersController(ILogger<UsersController> logger,  IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<ActionResult> Index()
        {
            UserListResponse userListResponse = new UserListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var response = await httpClient.GetAsync("http://localhost:61717/api/User");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userListResponse = JsonConvert.DeserializeObject<UserListResponse>(apiResponse);
                    }
                    else
                    {
                        // Logica por desarrollar //       
                    }
                }

                return View(userListResponse.data);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los usuarios", ex.ToString());
            }

            return View();
        }


        public async Task<ActionResult> Details(int id)
        {
            UserResponse userResponse = new UserResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"http://localhost:61717/api/User/id?Id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userResponse = JsonConvert.DeserializeObject<UserResponse>(apiResponse);
                }
                else
                {
                    // Logica por desarrollar //       
                }
            }
            return View(userResponse.data);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateRequest userCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                userCreateRequest.CreationDate = DateTime.Now;
                userCreateRequest.CreationUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(userCreateRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:61717/api/User/Save", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = baseResponse.Message;
                        return View();
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult>  Edit(int id)
        {

            UserResponse userResponse = new UserResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"http://localhost:61717/api/User/id?Id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userResponse = JsonConvert.DeserializeObject<UserResponse>(apiResponse);
                }
                else
                {
                    // Logica por desarrollar //       
                }
            }

            return View(userResponse.data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserUpdateRequest userUpdateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(userUpdateRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync("http://localhost:61717/api/User/Update", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode) 
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = baseResponse.Message;
                        return View();
                    }
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
