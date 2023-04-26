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
    public class PackagePlanRepositories
    {
        TaskPoolContext db = new TaskPoolContext();
        public async Task<JqueryPackagePlanDatatableResponse> GetPackagePlan(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            #region Variable Section
            filterData = filterData.Replace("\\", "");
            Package_Plan filterObj = JsonConvert.DeserializeObject<Package_Plan>(filterData);

            int sortColumnIndex = iSortCol_0;

            Func<Package_Plan, object> orderingFunction = (c => sortColumnIndex == 2 ? (object)c.PackageName : sortColumnIndex == 3 ? (object)c.Price :
                                                                    sortColumnIndex == 4 ? (object)c.Days : (object)c.id);
            List<Package_Plan> _dataList;
            List<Package_Plan> dList;
            int iTotal, iFilteredTotal;
            #endregion
            using (TaskPoolContext _db = new TaskPoolContext())
            {
                #region Fetching the data

                iTotal = (from tblPlan in _db.Package_Plan where tblPlan.DeleteFlag == false select tblPlan).Count();

                dList = (from tblAuther in _db.Package_Plan.AsEnumerable()
                         where tblAuther.DeleteFlag == false
                         && (filterObj.PackageName.Length > 0 ? tblAuther.PackageName.ToLower().Contains(filterObj.PackageName.ToLower()) : tblAuther.id != null)
                         select new Package_Plan
                         {
                             id = tblAuther.id,
                             PackageName = tblAuther.PackageName,
                             Price = tblAuther.Price,
                             Days = tblAuther.Days
                         }).ToList();

                iFilteredTotal = dList.Count();

                if (sSortDir_0 == "asc")
                    _dataList = dList.OrderBy(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                else
                    _dataList = dList.OrderByDescending(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                #endregion
            }
            //var CategoryList = db.Package_Plan.Select(a => a).Take(6).ToList();
            return new JqueryPackagePlanDatatableResponse() { sEcho = sEcho, iTotalRecords = iTotal, iTotalDisplayRecords = iFilteredTotal, aaData = _dataList };
        }
        public async Task<GetPackagesResponse> GetSinglePackagePlan(int id)
        {
            var PackageList = db.Package_Plan.Where(a => a.id == id).ToList();
            return new GetPackagesResponse() { dataList = PackageList };
        }
        public async Task<AddPackagePlanResponse> AddPackagePlan(AddPackagePlan addPackagePlan)
        {
            Package_Plan pc;
            try
            {

                if (addPackagePlan.id == 0)
                {
                    pc = new Package_Plan()
                    {
                        PackageName = addPackagePlan.PackageName,
                        Price = addPackagePlan.Price,
                        Days = addPackagePlan.Days,
                        DeleteFlag = false
                    };
                    db.Package_Plan.Add(pc);
                }
                else
                {
                    pc = db.Package_Plan.Where(a => a.id == addPackagePlan.id).FirstOrDefault();
                    pc.PackageName = addPackagePlan.PackageName;
                    pc.Price = addPackagePlan.Price;
                    pc.Days = addPackagePlan.Days;
                }
                db.SaveChanges();

                return new AddPackagePlanResponse() { id = pc.id, status = 0, Message = "Data saved successfully." };
            }
            catch (Exception)
            {
                return new AddPackagePlanResponse() { id = 0, status = 1, Message = "Problem occure." };
            }
        }
        public async Task<AddPackagePlanResponse> DeletePackagePlan(AddPackagePlan addPackagePlan)
        {

            int[] categoryIds = addPackagePlan.ids.Split(',').Select(int.Parse).ToArray();
            IEnumerable<Package_Plan> pc = db.Package_Plan.Where(a => categoryIds.Contains(a.id));
            foreach (var item in pc)
            {
                item.DeleteFlag = true;
            }
            db.SaveChanges();
            return new AddPackagePlanResponse() { Message = "Data Deleted Successfully" };

        }
    }
}
