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
    public class PaymentDetailsRepositories
    {
        TaskPoolContext db = new TaskPoolContext();
        public async Task<JqueryPaymentDetailsDatatableResponse> GetPaymentDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            #region Variable Section
            DateTime? fromDate;
            DateTime?toDate;
            filterData = filterData.Replace("\\", "");
            PaymentDetailsResponce filterObj = JsonConvert.DeserializeObject<PaymentDetailsResponce>(filterData);

            int sortColumnIndex = iSortCol_0;

            Func<PaymentDetailsResponce, object> orderingFunction = (c => sortColumnIndex == 2 ? (object)c.UserName : sortColumnIndex == 3 ? (object)c.PackageName :
                                                                    sortColumnIndex == 4 ? (object)c.PaymentAmount :
                                                                    sortColumnIndex == 5 ? (object)c.PaymentTransationId :
                                                                    sortColumnIndex == 6 ? (object)c.PaymentDate :
                                                                    sortColumnIndex == 7 ? (object)c.PaymentComment :
                                                                    sortColumnIndex == 8 ? (object)c.PackageEndDate :
                                                                    sortColumnIndex == 9 ? (object)c.ReviewComment :
                                                                    sortColumnIndex == 10 ? (object)c.ReviewDate : (object)c.id);

            List<PaymentDetailsResponce> _dataList;
            List<PaymentDetailsResponce> dList;

            int iTotal, iFilteredTotal;
            #endregion
            using (TaskPoolContext _db = new TaskPoolContext())
            {
                try
                {
                    #region Fetching the data
                    if (!String.IsNullOrEmpty(filterObj.PaymentFromDate))
                        fromDate = Convert.ToDateTime(filterObj.PaymentFromDate);
                    else
                        fromDate = null;
                    if (!String.IsNullOrEmpty(filterObj.PaymentToDate))
                        toDate = Convert.ToDateTime(filterObj.PaymentToDate);
                    else
                        toDate = null;

                    iTotal = (from tblPaymentDetails in _db.Payment_Details where tblPaymentDetails.DeleteFlag == false select tblPaymentDetails).Count();
                    dList = (from tblPaymentDetails in _db.Payment_Details.AsEnumerable()
                             join tblUser in _db.User_Details.AsEnumerable() on tblPaymentDetails.UserId equals tblUser.id
                             join tblPackagePlan in _db.Package_Plan.AsEnumerable() on tblPaymentDetails.PackagePlanId equals tblPackagePlan.id
                             where tblPaymentDetails.DeleteFlag == false
                             && (filterObj.UserName.Length > 0 ? tblUser.Name.ToLower().Contains(filterObj.UserName.ToLower()) : tblPaymentDetails.Id != null)
                             && (filterObj.PaymentTransationId.Length > 0 ? tblPaymentDetails.PaymentTransationId.ToLower().Contains(filterObj.PaymentTransationId.ToLower()) : tblPaymentDetails.Id != null)
                             && ((fromDate != null) ? (tblPaymentDetails.PaymentDate.Value.Date >= fromDate) : tblPaymentDetails.Id != null)
                             && ((toDate != null) ? (tblPaymentDetails.PaymentDate.Value.Date < toDate.Value.AddDays(1)) : tblPaymentDetails.Id != null)
                             select new PaymentDetailsResponce
                             {
                                 id = tblPaymentDetails.Id,
                                 UserId = tblUser.id,
                                 UserName = tblUser.Name,
                                 PaymentAmount = tblPaymentDetails.PaymentAmount,
                                 PaymentTransationId = tblPaymentDetails.PaymentTransationId,
                                 PaymentComment = tblPaymentDetails.PaymentComment,
                                 PaymentDate = tblPaymentDetails.PaymentDate,
                                 PaymentDateStr = string.Format( "{0:dd-MMM-yyyy}", tblPaymentDetails.PaymentDate),
                                 ReviewComment = tblPaymentDetails.ReviewComment,
                                 ReviewDate = tblPaymentDetails.ReviewDate,
                                 PackagePlanId = tblPaymentDetails.PackagePlanId,
                                 PackageName = tblPackagePlan.PackageName,
                                 PackageEndDate = tblPaymentDetails.PackageEndDate,
                                 PackageEndDateStr = string.Format("{0:dd-MMM-yyyy}", tblPaymentDetails.PackageEndDate),
                             }).ToList();

                    iFilteredTotal = dList.Count();

                    if (sSortDir_0 == "asc")
                        _dataList = dList.OrderBy(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                    else
                        _dataList = dList.OrderByDescending(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                    #endregion
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            //var CategoryList = db.Project_Category.Select(a => a).Take(6).ToList();
            return new JqueryPaymentDetailsDatatableResponse() { sEcho = sEcho, iTotalRecords = iTotal, iTotalDisplayRecords = iFilteredTotal, aaData = _dataList };
        }

        public async Task<GetPaymentDetailsByUserResponse> GetPaymentDetailsByUser(int id)
        {
            var PaymentDetails = db.Payment_Details.Where(a => a.Id == id).ToList();
            return new GetPaymentDetailsByUserResponse() { dataList = PaymentDetails };
        }

        public async Task<UpdatePaymentDetailsByUserResponse> UpdatePaymentDetailsForUser(UpdatePaymentDetailsByUserRequest updatePaymentDetailsByUserRequest)
        {
            Payment_Details pd;
            Payment_Details_History pdh;
            try
            {
                int[] categoryIds = updatePaymentDetailsByUserRequest.ids.Split(',').Select(int.Parse).ToArray();
                for (int i = 0; i < categoryIds.Count(); i++)
                {
                    int Categoryid = categoryIds[i];
                    pd = db.Payment_Details.Where(a => a.Id == Categoryid).FirstOrDefault();
                    if (pd != null)
                    {
                        pd.ReviewComment = updatePaymentDetailsByUserRequest.Comment;
                        pd.ReviewerUserId = updatePaymentDetailsByUserRequest.ReviewerUserId;

                        AddPaymentDetailsHistory(pd);
                        db.SaveChanges();
                    }
                }
                return new UpdatePaymentDetailsByUserResponse() { id = 0, status = 0, Message = "Data saved successfully." };
            }
            catch (Exception ex)
            {
                return new UpdatePaymentDetailsByUserResponse() { id = 0, status = 1, Message = "Problem occure." };
            }
        }

        private void AddPaymentDetailsHistory(Payment_Details pd)
        {
            Payment_Details_History pdh = new Payment_Details_History()
            {
                UserId = pd.UserId,
                PaymentAmount = pd.PaymentAmount,
                PaymentTransationId = pd.PaymentTransationId,
                PaymentComment = pd.PaymentComment,
                PaymentDate = pd.PaymentDate,
                ReviewComment = pd.ReviewComment,
                ReviewDate = pd.ReviewDate,
                PackagePlanId = pd.PackagePlanId,
                PackageEndDate = pd.PackageEndDate,
                DeleteFlag = pd.DeleteFlag,
                ReviewerUserId = pd.ReviewerUserId,
                Payment_Ref_Id=pd.Id
                
            };
            db.Payment_Details_History.Add(pdh);
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
