using System;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.Models.Response;
using Renta_y_venta_de_peliculas.Web.APIservices.Interfaces;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class PeliculaController : Controller

    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly IPeliculaApiService peliculaApiService;
        private readonly ILogger<PeliculaController> logger;
        private readonly IConfiguration configuration;

        public PeliculaController(IPeliculaApiService peliculaApiService,
                                  ILogger<PeliculaController> logger,
                                  IConfiguration configuration)
        {
            this.peliculaApiService = peliculaApiService;
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {

            PeliculaListResponse peliculaListResponse = new();
            peliculaListResponse = await this.peliculaApiService.GetPeliculas();
            if (!peliculaListResponse.Success)
            {
                return View();

            }
           
            return View(peliculaListResponse.Data);
        }
        public async Task<ActionResult> Details(int id)
        {
            PeliculaResponse peliculaResponse = new PeliculaResponse();
            peliculaResponse = await this.peliculaApiService.GetPelicula(id);
            return View(peliculaResponse.Data);
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
                    StringContent content = new StringContent(JsonConvert.SerializeObject(peliculaCreate), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:44361/api/PeliculaAPI/SavePelicula", content);
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

        public async Task<ActionResult> Edit(int id)
        {
            PeliculaResponse peliculaResponse = new PeliculaResponse();
            using(var httpClient = new HttpClient(this.httpClientHandler))
            {
                var response = await httpClient.GetAsync($"https://localhost:44361/api/PeliculaAPI/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    peliculaResponse = JsonConvert.DeserializeObject<PeliculaResponse>(apiResponse);
                }
                else
                {
                    return BadRequest(response); ;
                }
            }
            return View(peliculaResponse.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PeliculaUpdateRequest peliculaUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                peliculaUpdate.modifyDate = DateTime.Now;
                peliculaUpdate.modifyUser = 1;
                using(var httpClient = new HttpClient(this.httpClientHandler))
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
                        return View(baseResponse);
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