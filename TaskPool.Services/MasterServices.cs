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
    public class MasterServices : IMasterServices
    {
        MasterRepositories _masterRepositories;
        PojectCategoryRepositories _pojectCategoryRepositories;
        PackagePlanRepositories _packagePlanRepositories;
        PaymentDetailsRepositories _paymentDetailsRepositories;
        UserDetailsRepositories _userDetailsRepositories;
        ProjectDetailsRepositories _projectDetailsRepositories;
        public MasterServices()
        {
            _masterRepositories = new MasterRepositories();
            _pojectCategoryRepositories = new PojectCategoryRepositories();
            _packagePlanRepositories = new PackagePlanRepositories();
            _paymentDetailsRepositories = new PaymentDetailsRepositories();
            _userDetailsRepositories = new UserDetailsRepositories();
            _projectDetailsRepositories = new ProjectDetailsRepositories();
        }
        //public async Task<GetPackagesResponse> GetPackages()
        //{
        //    var addProjectResponce = await _masterRepositories.GetPackages();
        //    return addProjectResponce;
        //}
        #region Project Category
        public async Task<JqueryProjectCategoryDatatableResponse> GetProjectCategory(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            var getProjectCategoryResponse = await _pojectCategoryRepositories.GetProjectCategory(iDisplayStart, iDisplayLength, sSearch, bEscapeRegex, iColumns, iSortingCols, iSortCol_0, sSortDir_0, sEcho, filterData);
            return getProjectCategoryResponse;
        }
        public async Task<GetCategoryMasterResponce> GetSingleProjectCategory(int id)
        {
            var getProjectCategoryResponse = await _pojectCategoryRepositories.GetSingleProjectCategory(id);
            return getProjectCategoryResponse;
        }
        public async Task<GetCategoryMasterResponce> GetProjectCategoryList()
        {
            var getProjectCategoryResponse = await _pojectCategoryRepositories.GetProjectCategoryList();
            return getProjectCategoryResponse;
        }
        public async Task<AddProjectCategoryResponse> AddProjectCategory(AddProjectCategory addProjectCategory)
        {
            var addProjectCategoryResponce = await _pojectCategoryRepositories.AddProjectCategory(addProjectCategory);
            return addProjectCategoryResponce;
        }
        public async Task<AddProjectCategoryResponse> DeleteProjectCategory(AddProjectCategory addProjectCategory)
        {
            var addProjectCategoryResponce = await _pojectCategoryRepositories.DeleteProjectCategory(addProjectCategory);
            return addProjectCategoryResponce;
        }
        #endregion

        #region Package Plan
        public async Task<JqueryPackagePlanDatatableResponse> GetPackagePlan(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            var getPackagePlanResponse = await _packagePlanRepositories.GetPackagePlan(iDisplayStart, iDisplayLength, sSearch, bEscapeRegex, iColumns, iSortingCols, iSortCol_0, sSortDir_0, sEcho, filterData);
            return getPackagePlanResponse;
        }
        public async Task<GetPackagesResponse> GetSinglePackagePlan(int id)
        {
            var getPackagePlanResponse = await _packagePlanRepositories.GetSinglePackagePlan(id);
            return getPackagePlanResponse;
        }
        public async Task<AddPackagePlanResponse> AddPackagePlan(AddPackagePlan addPackagePlan)
        {
            var addPackagePlanResponce = await _packagePlanRepositories.AddPackagePlan(addPackagePlan);
            return addPackagePlanResponce;
        }
        public async Task<AddPackagePlanResponse> DeletePackagePlan(AddPackagePlan addPackagePlan)
        {
            var addPackagePlanResponce = await _packagePlanRepositories.DeletePackagePlan(addPackagePlan);
            return addPackagePlanResponce;
        }
        #endregion

        #region Payment Details
        public async Task<JqueryPaymentDetailsDatatableResponse> GetPaymentDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            var getProjectCategoryResponse = await _paymentDetailsRepositories.GetPaymentDetails(iDisplayStart, iDisplayLength, sSearch, bEscapeRegex, iColumns, iSortingCols, iSortCol_0, sSortDir_0, sEcho, filterData);
            return getProjectCategoryResponse;
        }
        public async Task<GetPaymentDetailsByUserResponse> GetPaymentDetailsByUser(int id)
        {
            var getProjectCategoryResponse = await _paymentDetailsRepositories.GetPaymentDetailsByUser(id);
            return getProjectCategoryResponse;
        }
        public async Task<UpdatePaymentDetailsByUserResponse> UpdatePaymentDetailsForUser(UpdatePaymentDetailsByUserRequest updatePaymentDetailsByUserRequest)
        {
            var addProjectCategoryResponce = await _paymentDetailsRepositories.UpdatePaymentDetailsForUser(updatePaymentDetailsByUserRequest);
            return addProjectCategoryResponce;
        }
        //public async Task<AddProjectCategoryResponse> DeletePaymentDetails(AddProjectCategory addProjectCategory)
        //{
        //    var addProjectCategoryResponce = await _pojectCategoryRepositories.DeleteProjectCategory(addProjectCategory);
        //    return addProjectCategoryResponce;
        //}
        #endregion

        #region User Details
        public async Task<JqueryUserDetailsDatatableResponse> GetUserDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            var getProjectCategoryResponse = await _userDetailsRepositories.GetUserDetails(iDisplayStart, iDisplayLength, sSearch, bEscapeRegex, iColumns, iSortingCols, iSortCol_0, sSortDir_0, sEcho, filterData);
            return getProjectCategoryResponse;
        }
        public async Task<GetVerificationDetailsByUserResponse> GetVerificationDetailsByUser(int id)
        {
            var getVerificationDetailsResponse = await _userDetailsRepositories.GetVerificationDetailsByUser(id);
            return getVerificationDetailsResponse;
        }
        public async Task<UpdateUserVerificationDetailsByUserResponse> UpdateVerificationDetailsForUser(VerifyUserDetailsRequest verifyUserDetailsRequest)
        {
            var addProjectCategoryResponce = await _userDetailsRepositories.UpdateVerificationDetailsForUser(verifyUserDetailsRequest);
            return addProjectCategoryResponce;
        }
        //public async Task<AddProjectCategoryResponse> DeletePaymentDetails(AddProjectCategory addProjectCategory)
        //{
        //    var addProjectCategoryResponce = await _pojectCategoryRepositories.DeleteProjectCategory(addProjectCategory);
        //    return addProjectCategoryResponce;
        //}
        #endregion

        #region Project Details
        public async Task<JqueryProjectDetailsDatatableResponse> GetProjectDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            var getProjectResponse = await _projectDetailsRepositories.GetProjectDetails(iDisplayStart, iDisplayLength, sSearch, bEscapeRegex, iColumns, iSortingCols, iSortCol_0, sSortDir_0, sEcho, filterData);
            return getProjectResponse;
        }
        public async Task<GetProjectDetailsByUserResponse> GetProjectDetailsByUser(int UserId)
        {
            var getProjectCategoryResponse = await _projectDetailsRepositories.GetProjectDetailsByUser(UserId);
            return getProjectCategoryResponse;
        }
        public async Task<UpdateProjectDetailsByUserResponse> UpdateProjectDetails(VerifyProjectDetailsRequest verifyProjectDetailsRequest)
        {
            var addProjectCategoryResponce = await _projectDetailsRepositories.UpdateProjectDetails(verifyProjectDetailsRequest);
            return addProjectCategoryResponce;
        }

        #endregion
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
