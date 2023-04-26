using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskPool.Common;
using TaskPool.Models;
using TaskPool.Models.Request;
using TaskPool.Services.Interfaces;

namespace TaskPool.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Landing")]    
    public class LandingPageController : ApiController
    {
        ApplicationServiceFactory _applicationServiceFactory;

        public LandingPageController()
        {
            _applicationServiceFactory = new ApplicationServiceFactory();
        }

        [HttpGet, Route("landing/GetGategory")]
        public async Task<GetCategoryResponce> GetGategory()
        {
            var response = new GetCategoryResponce();
            var ApiLog = new ApiLog();
            BindLogInfo("GetGategory", ApiLog);
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILandingServices>().GetCategory();
                ApiLog.HttpResponseCode = (int)HttpStatusCode.OK;
                ApiLog.Response = JsonConvert.SerializeObject(response);
            }
            catch (ApiException apiEx)
            {
                ApiLog.ErrorMessage = apiEx.ToString();
                var message = new HttpResponseMessage(apiEx.StatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(apiEx.Response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                ApiLog.ErrorMessage = ex.ToString();
                ApiLog.Response = JsonConvert.SerializeObject(response);
                response.invalidReasons.Add("Internal application error");
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            finally
            {
                try
                {
                    SaveApiLog(ApiLog);
                }
                catch (Exception ex)
                {
                    //TODO : Log API Exception to database
                }
            }
            return response;
        }

        [HttpPost, Route("landing/AddProject")]
        public async Task<AddProjectResponce> AddProject([FromBody] AddProjectRequest addProjectRequest)
        {
            var response = new AddProjectResponce();
            var ApiLog = new ApiLog();
            BindLogInfo("AddProject", ApiLog);
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILandingServices>().AddProject(addProjectRequest);
                ApiLog.HttpResponseCode = (int)HttpStatusCode.OK;
                ApiLog.Response = JsonConvert.SerializeObject(response);
            }
            catch (ApiException apiEx)
            {
                ApiLog.ErrorMessage = apiEx.ToString();
                var message = new HttpResponseMessage(apiEx.StatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(apiEx.Response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                ApiLog.ErrorMessage = ex.ToString();
                ApiLog.Response = JsonConvert.SerializeObject(response);
                ApiLog.Request = JsonConvert.SerializeObject(addProjectRequest);
                response.invalidReasons.Add("Internal application error");
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            finally
            {
                try
                {
                    SaveApiLog(ApiLog);
                }
                catch (Exception ex)
                {
                    //TODO : Log API Exception to database
                }
            }
            return response;
        }

        [HttpPost, Route("landing/GetPostByRadious")]
        public async Task<GetPostResponce> GetPostByRadious([FromBody] GetPostRequest getPostRequest)
        {
            var response = new GetPostResponce();
            var ApiLog = new ApiLog();
            BindLogInfo("GetPostByRadious", ApiLog);
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILandingServices>().GetPostByRadious(getPostRequest);
                ApiLog.HttpResponseCode = (int)HttpStatusCode.OK;
                ApiLog.Response = JsonConvert.SerializeObject(response);
            }
            catch (ApiException apiEx)
            {
                ApiLog.ErrorMessage = apiEx.ToString();
                var message = new HttpResponseMessage(apiEx.StatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(apiEx.Response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                ApiLog.ErrorMessage = ex.ToString();
                ApiLog.Response = JsonConvert.SerializeObject(response);
                ApiLog.Request = JsonConvert.SerializeObject(getPostRequest);
                response.invalidReasons.Add("Internal application error");
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            finally
            {
                try
                {
                    SaveApiLog(ApiLog);
                }
                catch (Exception ex)
                {
                    //TODO : Log API Exception to database
                }
            }
            return response;
        }

        [HttpPost, Route("landing/GetPostByUser")]
        public async Task<GetPostByUserResponce> GetPostByUser([FromBody] GetPostByUserRequest getPostByUserRequest)
        {
            var response = new GetPostByUserResponce();
            var ApiLog = new ApiLog();
            BindLogInfo("GetPostByUser", ApiLog);
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILandingServices>().GetPostByUser(getPostByUserRequest);
                ApiLog.HttpResponseCode = (int)HttpStatusCode.OK;
                ApiLog.Response = JsonConvert.SerializeObject(response);
            }
            catch (ApiException apiEx)
            {
                ApiLog.ErrorMessage = apiEx.ToString();
                var message = new HttpResponseMessage(apiEx.StatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(apiEx.Response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                ApiLog.ErrorMessage = ex.ToString();
                ApiLog.Response = JsonConvert.SerializeObject(response);
                ApiLog.Request = JsonConvert.SerializeObject(getPostByUserRequest);
                response.invalidReasons.Add("Internal application error");
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(message);
            }
            finally
            {
                try
                {
                    SaveApiLog(ApiLog);
                }

                catch (Exception ex)
                {
                    //TODO : Log API Exception to database
                }

            }
            return response;
        }

        [HttpPost, Route("landing/GetLocationName")]
        public async Task<GoogleLocation> GetLocationName([FromBody] GetPostRequest getPostRequest)
        {
            var response = new GoogleLocation();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILandingServices>().GetGoogleLocation(getPostRequest);
                ApiLog.HttpResponseCode = (int)HttpStatusCode.OK;
                ApiLog.Response = JsonConvert.SerializeObject(response);
            }
            catch (ApiException apiEx)
            {
                ApiLog.ErrorMessage = apiEx.ToString();
                var message = new HttpResponseMessage(apiEx.StatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(apiEx.Response), Encoding.UTF8, "application/json")
                };

                //TODO : Send Mail for error notification with statusCode,and ApiEx
                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                ApiLog.ErrorMessage = ex.ToString();
                response.invalidReasons.Add("Internal application error");
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
                };
                //TODO : Send Mail for error notification with statusCode,and ApiEx 
                throw new HttpResponseException(message);
            }
            finally
            {
                try
                {
                    //TODO Save Log information to database | Note : add generic class to log information in database
                }

                catch (Exception ex)
                {
                    //TODO : Log API Exception to database
                }

            }
            return response;
        }

        private static void BindLogInfo(string EndPointName, ApiLog ApiLog)
        {
            ApiLog.EndPointName = EndPointName;
            ApiLog.HttpResponseCode = (int)HttpStatusCode.InternalServerError;
        }

        public void SaveApiLog(ApiLog ApiLog)
        {
            ApiLog.EndTime = DateTime.Now;
            ApiLog.ElapsedTime = Convert.ToInt64(ApiLog.EndTime.Subtract(ApiLog.StartTime).TotalMilliseconds);
            _applicationServiceFactory.GetApplicationService<ILandingServices>().SaveApiLog(ApiLog);
        }

    }
}
