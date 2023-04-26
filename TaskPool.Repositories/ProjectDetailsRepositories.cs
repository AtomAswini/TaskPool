using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPool.Models;
using TaskPool.Models.Request;
using System.Web;
using Newtonsoft.Json;

namespace TaskPool.Repositories
{
    public class ProjectDetailsRepositories
    {
        TaskPoolContext db = new TaskPoolContext();
        public async Task<JqueryProjectDetailsDatatableResponse> GetProjectDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            #region Variable Section
            filterData = filterData.Replace("\\", "");
            ProjectDetailsResponce filterObj = JsonConvert.DeserializeObject<ProjectDetailsResponce>(filterData);

            int sortColumnIndex = iSortCol_0;

            Func<ProjectDetailsResponce, object> orderingFunction = (c => sortColumnIndex == 2 ? (object)c.UserName : sortColumnIndex == 3 ? (object)c.CategoryName :
            sortColumnIndex == 4 ? (object)c.ProjectTitle : sortColumnIndex == 5 ? (object)c.ProjectBudgetFrom : sortColumnIndex == 6 ? (object)c.LocationName :
            sortColumnIndex == 7 ? (object)c.IsDelete : sortColumnIndex == 8 ? (object)c.IsComplete : sortColumnIndex == 9 ? (object)c.Address :
            sortColumnIndex == 10 ? (object)c.ProjectDescription : (object)c.id);

            List<ProjectDetailsResponce> _dataList;
            List<ProjectDetailsResponce> dList;

            int iTotal, iFilteredTotal;
            #endregion
            using (TaskPoolContext _db = new TaskPoolContext())
            {
                #region Fetching the data

                iTotal = (from tblProjectDetails in _db.Project_Details where tblProjectDetails.DeleteFlag == false && tblProjectDetails.IsActive == false select tblProjectDetails).Count();

                dList = (from tblProjectDetails in _db.Project_Details.AsEnumerable()
                         join tblProjectCategory in _db.Project_Category.AsEnumerable() on tblProjectDetails.CagegoryId equals tblProjectCategory.id
                         join tblUser in _db.User_Details.AsEnumerable() on tblProjectDetails.UserId equals tblUser.id
                         where tblProjectDetails.DeleteFlag == false && tblProjectDetails.IsActive == false && (tblProjectDetails.IsProjectReject == false || tblProjectDetails.IsProjectReject == null)
                         && (filterObj.UserName.Length > 0 ? tblUser.Name.ToLower().Contains(filterObj.UserName.ToLower()) : tblProjectDetails.id != null)
                         && (filterObj.CategoryId != null ? tblProjectCategory.id == filterObj.CategoryId : tblProjectDetails.id != null)
                         select new ProjectDetailsResponce
                         {
                             id = tblProjectDetails.id,
                             UserId = tblUser.id,
                             UserName = tblUser.Name,
                             CategoryId = tblProjectCategory.id,
                             CategoryName = tblProjectCategory.Category,
                             ProjectBudgetTo = tblProjectDetails.ProjectBudgetTo,
                             ProjectBudgetFrom = tblProjectDetails.ProjectBudgetFrom,
                             ProjectTitle = tblProjectDetails.ProjectTitle,
                             Address = tblProjectDetails.Address,
                             ProjectDescription = tblProjectDetails.ProjectDescription,
                             LocationName = tblProjectDetails.LocationName,
                             IsDelete = tblProjectDetails.IsDelete,
                             IsComplete = tblProjectDetails.IsComplete,
                             IsActive = tblProjectDetails.IsActive,
                             Image = tblProjectDetails.Image

                         }).ToList();

                iFilteredTotal = dList.Count();

                if (sSortDir_0 == "asc")
                    _dataList = dList.OrderBy(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                else
                    _dataList = dList.OrderByDescending(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                #endregion
            }
            //var CategoryList = db.Project_Category.Select(a => a).Take(6).ToList();
            return new JqueryProjectDetailsDatatableResponse() { sEcho = sEcho, iTotalRecords = iTotal, iTotalDisplayRecords = iFilteredTotal, aaData = _dataList };
        }

        public async Task<GetProjectDetailsByUserResponse> GetProjectDetailsByUser(int Id)
        {
            //var ProjectDetailsList = db.Project_Details.Where(a => a.UserId == UserId).ToList();
            var dList = (from tblProjectDetails in db.Project_Details.AsEnumerable()
                     join tblProjectCategory in db.Project_Category.AsEnumerable() on tblProjectDetails.CagegoryId equals tblProjectCategory.id
                     join tblUser in db.User_Details.AsEnumerable() on tblProjectDetails.UserId equals tblUser.id
                     where tblProjectDetails.DeleteFlag == false && tblProjectDetails.IsActive == false && tblProjectDetails.id==Id
                     select new ProjectDetailsResponce
                     {
                         id = tblProjectDetails.id,
                         UserId = tblUser.id,
                         UserName = tblUser.Name,
                         CategoryId = tblProjectCategory.id,
                         CategoryName = tblProjectCategory.Category,
                         ProjectBudgetTo = tblProjectDetails.ProjectBudgetTo,
                         ProjectBudgetFrom = tblProjectDetails.ProjectBudgetFrom,
                         ProjectTitle = tblProjectDetails.ProjectTitle,
                         Address = tblProjectDetails.Address,
                         ProjectDescription = tblProjectDetails.ProjectDescription,
                         LocationName = tblProjectDetails.LocationName,
                         IsDelete = tblProjectDetails.IsDelete,
                         IsComplete = tblProjectDetails.IsComplete,
                         IsActive = tblProjectDetails.IsActive,
                         Image = tblProjectDetails.Image,
                         CommitionAmount=tblProjectDetails.CommitionAmount,
                         CommitionPaidAmount=tblProjectDetails.CommitionPaidAmount,
                         CommitionPaidStatus=tblProjectDetails.CommitionPaidStatus,
                         Latitude=tblProjectDetails.Latitude,
                         Longitude=tblProjectDetails.Longitude,
                         ReviewComment=tblProjectDetails.ReviewComment
                     }).ToList();
            return new GetProjectDetailsByUserResponse() { dataList = dList };
        }

        public async Task<UpdateProjectDetailsByUserResponse> UpdateProjectDetails(VerifyProjectDetailsRequest verifyProjectDetailsRequest)
        {
            Project_Details pd;
            try
            {
                int[] Ids = verifyProjectDetailsRequest.ids.Split(',').Select(int.Parse).ToArray();
                for (int i = 0; i < Ids.Count(); i++)
                {
                    int id = Ids[i];
                    pd = db.Project_Details.Where(a => a.id == id).FirstOrDefault();
                    if (pd != null)
                    {
                        pd.ReviewComment = verifyProjectDetailsRequest.Comment;
                        pd.ReviewerUserId = verifyProjectDetailsRequest.ReviewerUserId;
                        pd.IsActive = verifyProjectDetailsRequest.IsVerified != null ? true : false;
                        pd.IsProjectReject = verifyProjectDetailsRequest.IsActiveReject != null ? true : false;

                        addProjectDetailsHistory(pd);
                        db.SaveChanges();
                    }
                }

                return new UpdateProjectDetailsByUserResponse() { id = 0, status = 0, Message = "Data saved successfully." };
            }
            catch (Exception ex)
            {
                return new UpdateProjectDetailsByUserResponse() { id = 0, status = 1, Message = "Problem occure." };
            }
        }

        private void addProjectDetailsHistory(Project_Details pd)
        {
            Project_Details_History pdh = new Project_Details_History()
            {
                ReviewComment = pd.ReviewComment,
                ReviewerUserId = pd.ReviewerUserId,
                IsActive = pd.IsActive,
                IsProjectReject = pd.IsProjectReject,
                CreatedOn=pd.CreatedOn,
                UpdatedOn=pd.UpdatedOn,
                Project_Ref_Id=pd.id,
                ReviewDate=pd.ReviewDate
            };
            db.Project_Details_History.Add(pdh);
        }

        public async Task<AddProjectCategoryResponse> DeleteProjectCategory(AddProjectCategory addProjectCategory)
        {
            int[] categoryIds = addProjectCategory.ids.Split(',').Select(int.Parse).ToArray();
            IEnumerable<Project_Category> pc = db.Project_Category.Where(a => categoryIds.Contains(a.id));
            foreach (var item in pc)
            {
                item.DeleteFlag = true;
            }
            db.SaveChanges();
            return new AddProjectCategoryResponse() { Message = "Data Deleted Successfully" };
        }
    }
}
