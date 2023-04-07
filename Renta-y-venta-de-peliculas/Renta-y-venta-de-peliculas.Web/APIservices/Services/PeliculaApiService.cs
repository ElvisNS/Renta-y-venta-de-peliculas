using Newtonsoft.Json;
using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.APIservices.Interfaces;
using Renta_y_venta_de_peliculas.Web.Models.Response;

namespace Renta_y_venta_de_peliculas.Web.APIservices.Services
{
    public class PeliculaApiService : IPeliculaApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<PeliculaApiService> logger;
        private readonly string baseUrl;

        public PeliculaApiService(IHttpClientFactory httpClientFactory,
                                    IConfiguration configuration,
                                    ILogger<PeliculaApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];

        }

        public async Task<PeliculaResponse> GetPelicula(int id)
        {
            PeliculaResponse peliculaResponse = new PeliculaResponse();
            try
            {
                using (var httpclient = this.httpClientFactory.CreateClient())

                {
                    using (var response = await httpclient.GetAsync($"{this.baseUrl}/Pelicula/" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            peliculaResponse = JsonConvert.DeserializeObject<PeliculaResponse>(apiResponse);
                        }
                        else
                        {
                            return peliculaResponse;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                peliculaResponse.Message = "Error obteniendo las peliculas";
                peliculaResponse.Success = false;
                this.logger.LogError(peliculaResponse.Message, ex.ToString());
            }
            return peliculaResponse;
        }
        public async Task<PeliculaListResponse> GetPeliculas()
        {
            PeliculaListResponse peliculaListResponse = new PeliculaListResponse();

            try
            {
                using (var httpclient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpclient.GetAsync($"{this.baseUrl}/Pelicula"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            peliculaListResponse = JsonConvert.DeserializeObject<PeliculaListResponse>(apiResponse);
                        }
                        else
                        {
                            return peliculaListResponse;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                peliculaListResponse.Message = "Error obteniendo las peliculas";
                peliculaListResponse.Success = false;
                this.logger.LogError(peliculaListResponse.Message, ex.ToString());
            }
            return peliculaListResponse;
        }
        public Task<BaseResponse> Save(PeliculaCreateRequest peliculaModel)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Update(PeliculaUpdateRequest peliculaModel)
        {


            throw new NotImplementedException();
        }

    }
}

