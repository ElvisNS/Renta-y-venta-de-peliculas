using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Renta_y_venta_de_peliculas.Web.APIServices.Interfaces;
using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.Models.Response;
using System.Text;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class UsersController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly IUserApiService userApiService;
        private readonly ILogger<UsersController> logger;
        private readonly IConfiguration configuration;

        public UsersController(IUserApiService userApiService, ILogger<UsersController> logger,  IConfiguration configuration)
        {
            this.userApiService = userApiService;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<ActionResult> Index()
        {
            UserListResponse userListResponse = new UserListResponse();

            userListResponse = await this.userApiService.GetUsers();

            return View(userListResponse.data);
        }


        public async Task<ActionResult> Details(int id)
        {
            UserResponse userResponse = new UserResponse();

            userResponse = await this.userApiService.GetUser(id);

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

            baseResponse = await this.userApiService.Save(userCreateRequest);

            if (!baseResponse.Success)
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult>  Edit(int id)
        {

            UserResponse userResponse = new UserResponse();

            userResponse = await this.userApiService.GetUser(id);

            return View(userResponse.data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserUpdateRequest userUpdateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            baseResponse = await this.userApiService.Update(userUpdateRequest);

            if (!baseResponse.Success)
            {
                ViewBag.Message = baseResponse.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
