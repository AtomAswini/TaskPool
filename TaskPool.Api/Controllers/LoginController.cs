using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using TaskPool.Services;
using TaskPool.Models;
using TaskPool.Common;
using TaskPool.Api.Common;
using TaskPool.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace TaskPool.Api.Controllers
{
    [RoutePrefix("api/login")]    
    public class LoginController : ApiController
    {       
      
        ApplicationServiceFactory _applicationServiceFactory = new ApplicationServiceFactory();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpGet,Route("login/validate/{phonenumber}")]
        public async Task<LoginResponce> ValidatePhoneNumber(string phoneNumber)
        {
            var response = new LoginResponce();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILoginService>().CreateUser(phoneNumber);

                ApiLog.ErrorMessage = response.invalidReasons.Count > 0 ? response.invalidReasons[0] : "";
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
                //TODO :Log with Service Name
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

        [HttpGet, Route("Manage/login/{UserName}/{Password}")]
        public async Task<GetUserByUserNamePasswordResponce> GetUserByUserNamePassword(string userName, string password)
        {
            var response = new GetUserByUserNamePasswordResponce();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<ILoginService>().GetUserByUserNamePassword(userName,password);
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
                //TODO :Log with Service Name
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

    }
}
