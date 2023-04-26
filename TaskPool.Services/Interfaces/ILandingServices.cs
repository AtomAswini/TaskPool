using System;
using System.Threading.Tasks;
using TaskPool.Common;
using TaskPool.Models;
using TaskPool.Models.Request;

namespace TaskPool.Services.Interfaces
{
    public interface ILandingServices : IDisposable
    {

        Task<GetCategoryResponce> GetCategory();
        Task<AddProjectResponce> AddProject(AddProjectRequest addProjectRequest);
        Task<GetPostResponce> GetPostByRadious(GetPostRequest getPostRequest);
        Task<GoogleLocation> GetGoogleLocation(GetPostRequest getPostRequest);
        Task<GetPostByUserResponce> GetPostByUser(GetPostByUserRequest getPostByUserRequest);
        void SaveApiLog(ApiLog ApiLog);
    }
}
