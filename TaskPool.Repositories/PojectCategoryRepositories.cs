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
    public class PojectCategoryRepositories
    {
        TaskPoolContext db = new TaskPoolContext();
        public async Task<JqueryProjectCategoryDatatableResponse> GetProjectCategory(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            #region Variable Section
            filterData = filterData.Replace("\\", "");
            Project_Category filterObj = JsonConvert.DeserializeObject<Project_Category>(filterData);

            int sortColumnIndex = iSortCol_0;

            Func<Project_Category, object> orderingFunction = (c => sortColumnIndex == 2 ? (object)c.Category : sortColumnIndex == 3 ? (object)c.Description :
                                                                    sortColumnIndex == 4 ? (object)c.IsActive : (object)c.id);
            List<Project_Category> _dataList;
            List<Project_Category> dList;
            int iTotal, iFilteredTotal;
            #endregion
            using (TaskPoolContext _db = new TaskPoolContext())
            {
                #region Fetching the data

                iTotal = (from tblCategory in _db.Project_Category where tblCategory.DeleteFlag == false select tblCategory).Count();

                dList = (from tblAuther in _db.Project_Category.AsEnumerable()
                         where tblAuther.DeleteFlag == false
                         && (filterObj.Category.Length > 0 ? tblAuther.Category.ToLower().Contains(filterObj.Category.ToLower()) : tblAuther.id != null)
                         && ((filterObj.IsActive != null) ? (tblAuther.IsActive == filterObj.IsActive) : tblAuther.id != null)
                         select new Project_Category
                         {
                             id = tblAuther.id,
                             Category = tblAuther.Category,
                             Description = tblAuther.Description,
                             IsActive = tblAuther.IsActive
                         }).ToList();

                iFilteredTotal = dList.Count();

                if (sSortDir_0 == "asc")
                    _dataList = dList.OrderBy(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                else
                    _dataList = dList.OrderByDescending(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                #endregion
            }
            //var CategoryList = db.Project_Category.Select(a => a).Take(6).ToList();
            return new JqueryProjectCategoryDatatableResponse() { sEcho = sEcho, iTotalRecords = iTotal, iTotalDisplayRecords = iFilteredTotal, aaData = _dataList };
        }
        public async Task<GetCategoryMasterResponce> GetSingleProjectCategory(int id)
        {
            var CategoryList = db.Project_Category.Where(a => a.id == id).ToList();
            return new GetCategoryMasterResponce() { dataList = CategoryList };
        }
        public async Task<GetCategoryMasterResponce> GetProjectCategoryList()
        {
            var CategoryList = db.Project_Category.Where(a => a.DeleteFlag == false).ToList();
            return new GetCategoryMasterResponce() { dataList = CategoryList };
        }
        public async Task<AddProjectCategoryResponse> AddProjectCategory(AddProjectCategory addProjectCategory)
        {
            Project_Category pc;
            try
            {
                if (addProjectCategory.id == 0)
                {
                    pc = new Project_Category()
                    {
                        Category = addProjectCategory.Category,
                        Description = addProjectCategory.Description,
                        IsActive = addProjectCategory.IsActive,
                        DeleteFlag = false
                    };
                    db.Project_Category.Add(pc);
                }
                else
                {
                    pc = db.Project_Category.Where(a => a.id == addProjectCategory.id).FirstOrDefault();
                    pc.Category = addProjectCategory.Category;
                    pc.Description = addProjectCategory.Description;
                    pc.IsActive = addProjectCategory.IsActive;
                }
                db.SaveChanges();
                return new AddProjectCategoryResponse() { id = pc.id, status = 0, Message = "Data saved successfully." };
            }
            catch (Exception)
            {
                return new AddProjectCategoryResponse() { id = 0, status = 1, Message = "Problem occure." };
            }
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
