using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Renta_y_venta_de_peliculas.Web.Models.Response;
using Renta_y_venta_de_peliculas.Web.Models.Request;
using System.Text;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class PeliculaController : Controller

    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<PeliculaController> logger;
        private readonly IConfiguration configuration;

        public PeliculaController(ILogger<PeliculaController> logger,
                                  IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            PeliculaListResponse peliculaListResponse = new();

            try
            {
                using var httpClient = new HttpClient(this.httpClientHandler);
                var response = await httpClient.GetAsync("https://localhost:44361/api/PeliculaAPI");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    peliculaListResponse = JsonConvert.DeserializeObject<PeliculaListResponse>(apiResponse);
                }
                else
                {
                    ViewBag.Message = peliculaListResponse.Message;
                    return View(peliculaListResponse.Data);

                }

            }

            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo las peliculas", ex.ToString());
            }

            return View();
        }

        public async Task<ActionResult> Details(int id)
        {

            PeliculaResponse peliculaResponse = new PeliculaResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"https://localhost:44361/api/PeliculaAPI/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    peliculaResponse = JsonConvert.DeserializeObject<PeliculaResponse>(apiResponse);
                }
                else
                {
                    ViewBag.Message = peliculaResponse.Message;
                    return View(peliculaResponse.Data);
                }
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PeliculaCreateRequest peliculaCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
               peliculaCreate.createDate = DateTime.Now;
               peliculaCreate.createUser = 1;
               using (var httpClient = new HttpClient(this.httpClientHandler))
               {
                StringContent content = new StringContent(JsonConvert.SerializeObject(peliculaCreate), Encoding.UTF8,"application/Json");
                var response = await httpClient.PostAsync("https://localhost:44361/api/PeliculaAPI/SavePelicula", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
               
                if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                else
                    {
                       ViewBag.Message (baseResponse.Message);
                       return View();
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            PeliculaResponse peliculaResponse = new PeliculaResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"https://localhost:44361/api/PeliculaAPI/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    peliculaResponse = JsonConvert.DeserializeObject<PeliculaResponse>(apiResponse);
                }
                else
                {
                    ViewBag(peliculaResponse.Message);
                    return View();
                }
                
            }
            return View(peliculaResponse.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Edit(PeliculaUpdateRequest peliculaUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                peliculaUpdate.modifyDate = DateTime.Now;
                peliculaUpdate.modifyUser = 1; 
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(peliculaUpdate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("https://localhost:44361/api/PeliculaAPI/UpdatePelicula", content);
                   
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

        