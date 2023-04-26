using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Services.Interfaces;
using TaskPool.Repositories;
using TaskPool.Models;
using TaskPool.Common;
using TaskPool.Models.Request;

namespace TaskPool.Services
{
    public class LandingServices : ILandingServices
    {
        
        LandingRepositories _landingRepositories;
        public LandingServices()
        {
            _landingRepositories = new LandingRepositories();
        }
        public async Task<AddProjectResponce> AddProject(AddProjectRequest addProjectRequest)   
        {
            var addProjectResponce = await _landingRepositories.AddProject(addProjectRequest); 
            return addProjectResponce;
        }
        public async Task<GetCategoryResponce> GetCategory()
        {
            var getCategoryResponce = await _landingRepositories.GetCategory();
            return getCategoryResponce;
        }

        public async Task<GetPostResponce> GetPostByRadious(GetPostRequest getPostRequest)
        {
            var getPostResponce = await _landingRepositories.GetPostByRadious(getPostRequest);
            return getPostResponce;
        }

        public async Task<GoogleLocation> GetGoogleLocation(GetPostRequest getPostRequest)
        {
            var getGoogleLocationResponce = await _landingRepositories.GetGoogleLocation(getPostRequest);
            return getGoogleLocationResponce;
        }

        public async Task<GetPostByUserResponce> GetPostByUser(GetPostByUserRequest getPostByUserRequest)
        {
            var getPostByUserResponce = await _landingRepositories.GetPostByUser(getPostByUserRequest);
            return getPostByUserResponce;
        }

        public void SaveApiLog(ApiLog ApiLog)
        {
            try
            {
                _landingRepositories.InsertApiLog(ApiLog);
            }
            catch (Exception)
            {
                throw new Exception($" Api Log insert failed for user id - {ApiLog.UserId}");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
