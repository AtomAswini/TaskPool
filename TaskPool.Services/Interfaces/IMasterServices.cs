using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Repositories;
using TaskPool.Models;
using TaskPool.Models.Request;

namespace TaskPool.Services.Interfaces
{
    public interface IMasterServices : IDisposable
    {
        //Task<GetPackagesResponse> GetPackages(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData);

        Task<JqueryProjectCategoryDatatableResponse> GetProjectCategory(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData);
        Task<GetCategoryMasterResponce> GetSingleProjectCategory(int id);
        Task<GetCategoryMasterResponce> GetProjectCategoryList();
        Task<AddProjectCategoryResponse> AddProjectCategory(AddProjectCategory addProjectCategory);
        Task<AddProjectCategoryResponse> DeleteProjectCategory(AddProjectCategory addProjectCategory);

        Task<JqueryPackagePlanDatatableResponse> GetPackagePlan(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData);
        Task<GetPackagesResponse> GetSinglePackagePlan(int id);
        Task<AddPackagePlanResponse> AddPackagePlan(AddPackagePlan addPackagePlan);
        Task<AddPackagePlanResponse> DeletePackagePlan(AddPackagePlan addPackagePlan);

        Task<JqueryPaymentDetailsDatatableResponse> GetPaymentDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData);
        Task<GetPaymentDetailsByUserResponse> GetPaymentDetailsByUser(int id);
        Task<UpdatePaymentDetailsByUserResponse> UpdatePaymentDetailsForUser(UpdatePaymentDetailsByUserRequest addProjectCategory);

        Task<JqueryUserDetailsDatatableResponse> GetUserDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData);
        Task<GetVerificationDetailsByUserResponse> GetVerificationDetailsByUser(int id);
        Task<UpdateUserVerificationDetailsByUserResponse> UpdateVerificationDetailsForUser(VerifyUserDetailsRequest verifyUserDetailsRequest);

        Task<JqueryProjectDetailsDatatableResponse> GetProjectDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData);
        Task<GetProjectDetailsByUserResponse> GetProjectDetailsByUser(int UserId);
        Task<UpdateProjectDetailsByUserResponse> UpdateProjectDetails(VerifyProjectDetailsRequest verifyProjectDetailsRequest);
    }
}
