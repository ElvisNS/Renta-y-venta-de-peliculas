using Newtonsoft.Json;
using Renta_y_venta_de_peliculas.Web.APIServices.Interfaces;
using Renta_y_venta_de_peliculas.Web.Models.Request;
using Renta_y_venta_de_peliculas.Web.Models.Response;
using System.Text;

namespace Renta_y_venta_de_peliculas.Web.APIServices.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<UserApiService> logger;
        private readonly string baseUrl;

        public UserApiService(IHttpClientFactory httpClientFactory,
                                 IConfiguration configuration,
                                 ILogger<UserApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }
        public async Task<UserResponse> GetUser(int Id)
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/User/id?Id=" + Id))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            userResponse = JsonConvert.DeserializeObject<UserResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //       
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                userResponse.message = "Error obteniendo el estudiante";
                userResponse.sucess = false;
                this.logger.LogError(userResponse.message, ex.ToString());
            }

            return userResponse;
        }

        public async Task<UserListResponse> GetUsers()
        {
            UserListResponse userListResponse = new UserListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/User"))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            userListResponse = JsonConvert.DeserializeObject<UserListResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //       
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                userListResponse.message = "Error obteniendo los estudiante";
                userListResponse.sucess = false;
                this.logger.LogError(userListResponse.message, ex.ToString());
            }

            return userListResponse;
        }

        public async Task<BaseResponse> Save(UserCreateRequest userCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(userCreateRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:61717/api/User/Save", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                baseResponse.Message = "Error Guardando el estudiante";
                baseResponse.Success = false;
                this.logger.LogError(baseResponse.Message, ex.ToString());
            }
            return baseResponse;
        }

        public async Task<BaseResponse> Update(UserUpdateRequest userUpdateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(userUpdateRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync("http://localhost:61717/api/User/Update", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                baseResponse.Message = "Error Actualizando el estudiante";
                baseResponse.Success = false;
                this.logger.LogError(baseResponse.Message, ex.ToString());
            }
            return baseResponse;
        }
    }
}
