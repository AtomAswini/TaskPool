using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaskPool.Common;
using TaskPool.Models;
using TaskPool.Models.Request;

namespace TaskPool.Repositories
{
    public class LandingRepositories
    {
        TaskPoolContext db = new TaskPoolContext();

        public async Task<GetCategoryResponce> GetCategory()
        {
            try
            {
                var CategoryList = db.Project_Category.Select(a => a).Take(6).ToList();
                return new GetCategoryResponce() { Categorys = CategoryList };
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<AddProjectResponce> AddProject(AddProjectRequest addProjectRequest)
        {
            try
            {
                Project_Details pd = new Project_Details()
                {
                    UserId = addProjectRequest.UserId,
                    Address = addProjectRequest.Address,
                    ProjectTitle = addProjectRequest.ProjectTitle,
                    ProjectBudgetTo = Convert.ToInt32(addProjectRequest.ProjectBudgetTo),
                    ProjectBudgetFrom = Convert.ToInt32(addProjectRequest.ProjectBudgetFrom),
                    ProjectDescription = addProjectRequest.ProjectDescription,
                    CommitionAmount = addProjectRequest.CommitionAmount,
                    Latitude = addProjectRequest.Latitude,
                    Longitude = addProjectRequest.Longitude,
                    Image = addProjectRequest.Image,
                    CommitionPaidStatus = true,
                    CommitionPaidAmount = 0,
                    CagegoryId = addProjectRequest.CagegoryId,
                    IsActive = false,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                db.Project_Details.Add(pd);
                db.SaveChanges();
                return new AddProjectResponce() { id = pd.id };
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<GetPostResponce> GetPostByRadious(GetPostRequest getPostRequest)
        {
            try
            {
                using (var context = new TaskPoolContext())
                {
                    object[] xparams = {
                    new SqlParameter("@RADIUS",6),
                    new SqlParameter("@LAT", getPostRequest.Latitude),
                    new SqlParameter("@LONG", getPostRequest.Longitude),

                };

                    var result = context.Database
                        .SqlQuery<Project_Details>("exec GetPostByRadious @RADIUS,@LAT,@LONG", xparams)
                        .ToList();

                    return new GetPostResponce()
                    {
                        projectDetails = result
                    };
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<GoogleLocation> GetGoogleLocation(GetPostRequest getPostRequest)
        {
            try
            {
                var requestUri = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + getPostRequest.Latitude + "," + getPostRequest.Longitude + "&key=AIzaSyB73fhL8Onx15RbWjljCjI71DmqvubXyvs";

                using (var client = new HttpClient())
                {
                    var request = await client.GetAsync(requestUri);
                    var content = await request.Content.ReadAsStringAsync();
                    var jsonData = content;
                    return new GoogleLocation()
                    {
                        LocationDetails = jsonData
                    };
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<GetPostByUserResponce> GetPostByUser(GetPostByUserRequest getPostByUserRequest)
        {
            try
            {
                List<Project_Details> userProject_Details;
                List<Project_Details> userFavourites;
                using (var context = new TaskPoolContext())
                {

                    var command = db.Database.Connection.CreateCommand();
                    command.CommandText = "GetPostByUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", getPostByUserRequest.UserId));
                    db.Database.Connection.Open();
                    var reader = command.ExecuteReader();

                    userProject_Details = ((IObjectContextAdapter)db).ObjectContext.Translate<Project_Details>(reader).ToList();
                    reader.NextResult();
                    userFavourites = ((IObjectContextAdapter)db).ObjectContext.Translate<Project_Details>(reader).ToList();
                }

                return new GetPostByUserResponce()
                {
                    myPostDetails = userProject_Details,
                    myFavouritesDetails = userFavourites
                };

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (db.Database.Connection.State == ConnectionState.Open)
                    db.Database.Connection.Close();
            }
        }

        public void InsertApiLog(ApiLog ApiLog)
        {
            try
            {
                if (ApiLog == null)
                    return;

                var dbApiLog = new Logs()
                {
                    ip_address = ApiLog.IpAddress,
                    Userid = ApiLog.UserId,
                    request = ApiLog.Request,
                    response = ApiLog.Request,
                    error_message = ApiLog.ErrorMessage,
                    EndPointName = ApiLog.EndPointName,
                    http_response_code = ApiLog.HttpResponseCode
                };

                db.Logs.Add(dbApiLog);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
