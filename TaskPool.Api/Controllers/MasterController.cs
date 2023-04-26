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
using System.Web.Http.Cors;
using TaskPool.Models.Request;

namespace TaskPool.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Master")]
    public class MasterController : ApiController
    {
        ApplicationServiceFactory _applicationServiceFactory;

        public MasterController()
        {
            _applicationServiceFactory = new ApplicationServiceFactory();
        }
        

        #region Project Category

        [HttpGet, Route("Master/GetProjectCategory")]
        public async Task<JqueryProjectCategoryDatatableResponse> GetProjectCategory([FromUri] JqueryDatatableRequest category )
        {
            var response = new JqueryProjectCategoryDatatableResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetProjectCategory(category.iDisplayStart, category.iDisplayLength, category.sSearch, category.bEscapeRegex, category.iColumns, category.iSortingCols, category.iSortCol_0, category.sSortDir_0, category.sEcho, category.filterData);
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
                //response.invalidReasons.Add("Internal application error");
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

        [HttpGet, Route("Master/GetSingleProjectCategory")]
        public async Task<GetCategoryMasterResponce> GetSingleProjectCategory(int idVal)
        {
            var response = new GetCategoryMasterResponce();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetSingleProjectCategory(idVal);
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

        [HttpGet, Route("Master/GetProjectCategoryList")]
        public async Task<GetCategoryMasterResponce> GetProjectCategoryList()
        {
            var response = new GetCategoryMasterResponce();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetProjectCategoryList();
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

        [HttpPost, Route("Master/AddProjectCategory")]
        public async Task<AddProjectCategoryResponse> AddProjectCategory([FromBody] AddProjectCategory posting_data)
        {
            var response = new AddProjectCategoryResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().AddProjectCategory(posting_data);
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

        [HttpPost, Route("Master/DeleteProjectCategory")]
        public async Task<AddProjectCategoryResponse> DeleteProjectCategory([FromBody] AddProjectCategory addProjectCategory)
        {
            var response = new AddProjectCategoryResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().DeleteProjectCategory(addProjectCategory);
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
        #endregion

        #region Package Plan

        [HttpGet, Route("Master/GetPackagePlan")]
        public async Task<JqueryPackagePlanDatatableResponse> GetPackagePlan([FromUri] JqueryDatatableRequest packagePlan)
        {
            var response = new JqueryPackagePlanDatatableResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetPackagePlan(packagePlan.iDisplayStart, packagePlan.iDisplayLength, packagePlan.sSearch, packagePlan.bEscapeRegex, packagePlan.iColumns, packagePlan.iSortingCols, packagePlan.iSortCol_0, packagePlan.sSortDir_0, packagePlan.sEcho, packagePlan.filterData);
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
                //response.invalidReasons.Add("Internal application error");
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

        [HttpGet, Route("Master/GetSinglePackagePlan")]
        public async Task<GetPackagesResponse> GetSinglePackagePlan(int idVal)
        {
            var response = new GetPackagesResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetSinglePackagePlan(idVal);
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

        [HttpPost, Route("Master/AddPackagePlan")]
        public async Task<AddPackagePlanResponse> AddPackagePlan([FromBody] AddPackagePlan posting_data)
        {
            var response = new AddPackagePlanResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().AddPackagePlan(posting_data);
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

        [HttpPost, Route("Master/DeletePackagePlan")]
        public async Task<AddPackagePlanResponse> DeletePackagePlan([FromBody] AddPackagePlan addPackagePlan)
        {
            var response = new AddPackagePlanResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().DeletePackagePlan(addPackagePlan);
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

#endregion

        #region Payment Details

        [HttpGet, Route("Master/GetPaymentDetails")]
        public async Task<JqueryPaymentDetailsDatatableResponse> GetPaymentDetails([FromUri] JqueryDatatableRequest PaymentDetails)
        {
            var response = new JqueryPaymentDetailsDatatableResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetPaymentDetails(PaymentDetails.iDisplayStart, PaymentDetails.iDisplayLength,
                    PaymentDetails.sSearch, PaymentDetails.bEscapeRegex, PaymentDetails.iColumns, PaymentDetails.iSortingCols, PaymentDetails.iSortCol_0, PaymentDetails.sSortDir_0, PaymentDetails.sEcho, PaymentDetails.filterData);
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
                //response.invalidReasons.Add("Internal application error");
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

        [HttpGet, Route("Master/GetPaymentDetailsByUser")]
        public async Task<GetPaymentDetailsByUserResponse> GetPaymentDetailsByUser(int idVal)
        {
            var response = new GetPaymentDetailsByUserResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetPaymentDetailsByUser(idVal);
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

        [HttpPost, Route("Master/UpdatePaymentDetailsForUser")]
        public async Task<UpdatePaymentDetailsByUserResponse> UpdatePaymentDetailsForUser([FromBody] UpdatePaymentDetailsByUserRequest posting_data)
        {
            var response = new UpdatePaymentDetailsByUserResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().UpdatePaymentDetailsForUser(posting_data);
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
                //response.invalidReasons.Add("Internal application error");
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
       
        #endregion

        #region User Details

        [HttpGet, Route("Master/GetUserDetails")]
        public async Task<JqueryUserDetailsDatatableResponse> GetUserDetails([FromUri] JqueryDatatableRequest userDetails)
        {
            var response = new JqueryUserDetailsDatatableResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetUserDetails(userDetails.iDisplayStart, userDetails.iDisplayLength,
                    userDetails.sSearch, userDetails.bEscapeRegex, userDetails.iColumns, userDetails.iSortingCols, userDetails.iSortCol_0, userDetails.sSortDir_0, userDetails.sEcho, userDetails.filterData);
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
                //response.invalidReasons.Add("Internal application error");
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

        [HttpGet, Route("Master/GetVerificationDetailsByUser")]
        public async Task<GetVerificationDetailsByUserResponse> GetVerificationDetailsByUser(int idVal)
        {
            var response = new GetVerificationDetailsByUserResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetVerificationDetailsByUser(idVal);
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

        [HttpPost, Route("Master/UpdateVerificationDetailsForUser")]
        public async Task<UpdateUserVerificationDetailsByUserResponse> UpdateVerificationDetailsForUser([FromBody] VerifyUserDetailsRequest posting_data)
        {
            var response = new UpdateUserVerificationDetailsByUserResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().UpdateVerificationDetailsForUser(posting_data);
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

        #endregion

        #region Project Details

        [HttpGet, Route("Master/GetProjectDetails")]
        public async Task<JqueryProjectDetailsDatatableResponse> GetProjectDetails([FromUri] JqueryDatatableRequest ProjectDetails)
        {
            var response = new JqueryProjectDetailsDatatableResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetProjectDetails(ProjectDetails.iDisplayStart, ProjectDetails.iDisplayLength,
                    ProjectDetails.sSearch, ProjectDetails.bEscapeRegex, ProjectDetails.iColumns, ProjectDetails.iSortingCols, ProjectDetails.iSortCol_0, ProjectDetails.sSortDir_0, ProjectDetails.sEcho, ProjectDetails.filterData);
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
                //response.invalidReasons.Add("Internal application error");
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

        [HttpGet, Route("Master/GetProjectDetailsByUser")]
        public async Task<GetProjectDetailsByUserResponse> GetProjectDetailsByUser(int idVal)
        {
            var response = new GetProjectDetailsByUserResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().GetProjectDetailsByUser(idVal);
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

        [HttpPost, Route("Master/UpdateProjectDetails")]
        public async Task<UpdateProjectDetailsByUserResponse> UpdateProjectDetails([FromBody] VerifyProjectDetailsRequest posting_data)
        {
            var response = new UpdateProjectDetailsByUserResponse();
            var ApiLog = new ApiLog();
            try
            {
                response = await _applicationServiceFactory.GetApplicationService<IMasterServices>().UpdateProjectDetails(posting_data);
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

        #endregion
    }
}