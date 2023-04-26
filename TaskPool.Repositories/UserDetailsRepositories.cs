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
using TaskPool.Common;

namespace TaskPool.Repositories
{
    public class UserDetailsRepositories
    {
        TaskPoolContext db = new TaskPoolContext();
        public async Task<JqueryUserDetailsDatatableResponse> GetUserDetails(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex, int iColumns, int iSortingCols, int iSortCol_0, string sSortDir_0, int sEcho, string filterData)
        {
            #region Variable Section
            filterData = filterData.Replace("\\", "");
            UserDetailsResponce filterObj = JsonConvert.DeserializeObject<UserDetailsResponce>(filterData);

            int sortColumnIndex = iSortCol_0;

            Func<UserDetailsResponce, object> orderingFunction = (c => sortColumnIndex == 2 ? (object)c.Name : sortColumnIndex == 3 ? (object)c.PhoneNumber :
                                                                    sortColumnIndex == 4 ? (object)c.Email :
                                                                    sortColumnIndex == 5 ? (object)c.Address :
                                                                    sortColumnIndex == 6 ? (object)c.Identity_1 :
                                                                    sortColumnIndex == 7 ? (object)c.Identity_2 :
                                                                    sortColumnIndex == 8 ? (object)c.WorkTitle :
                                                                    sortColumnIndex == 9 ? (object)c.WorkDescription :
                                                                    sortColumnIndex == 10 ? (object)c.WorkContact :
                                                                    sortColumnIndex == 11 ? (object)c.ShopCompanyName :
                                                                    sortColumnIndex == 12 ? (object)c.VerificationComment :
                                                                    sortColumnIndex == 13 ? (object)c.VerificationDate :
                                                                    sortColumnIndex == 14 ? (object)c.IsTaskerActive :
                                                                    sortColumnIndex == 15 ? (object)c.IsUserActive :
                                                                    sortColumnIndex == 16 ? (object)c.IsPremiumUser :
                                                                    sortColumnIndex == 17 ? (object)c.CreatedOn :
                                                                    sortColumnIndex == 18 ? (object)c.UpdatedOn : (object)c.id);

            List<UserDetailsResponce> _dataList=null;
            List<UserDetailsResponce> dList;

            int iTotal=0, iFilteredTotal=0;
            #endregion
            try
            {
                using (TaskPoolContext _db = new TaskPoolContext())
                {
                    #region Fetching the data

                    iTotal = (from tblUserDetails in _db.User_Details where tblUserDetails.DeleteFlag == false && tblUserDetails.IsUserActive == false select tblUserDetails).Count();

                    dList = (from tblUserDetails in _db.User_Details.AsEnumerable()
                             //join tblUserVerification_Details in _db.UserVerification_Details.AsEnumerable() on tblUserDetails.id equals tblUserVerification_Details.UserId into tblUserDetailsVerification_Details
                             //from Uvd in tblUserDetailsVerification_Details.DefaultIfEmpty()
                             where tblUserDetails.DeleteFlag == false && tblUserDetails.IsTaskerActive == false && tblUserDetails.IsTaskerActiveReject == false 
                             && (filterObj.Name.Length > 0 ? tblUserDetails.Name.ToLower().Contains(filterObj.Name.ToLower()) : tblUserDetails.id != null)
                             && (filterObj.PhoneNumber.Length > 0 ? tblUserDetails.PhoneNumber.ToLower().Contains(filterObj.PhoneNumber.ToLower()) : tblUserDetails.id != null)
                             && ((filterObj.Email.Length > 0) ? (tblUserDetails.Email == filterObj.Email) : tblUserDetails.id != null)
                             select new UserDetailsResponce
                             {
                                 id = tblUserDetails.id,
                                 UserId = tblUserDetails.id,
                                 Name = tblUserDetails.Name,
                                 PhoneNumber = tblUserDetails.PhoneNumber,
                                 Email = tblUserDetails.Email,
                                 Address = tblUserDetails.Address,
                                 Identity_1 = tblUserDetails.Identity_1,
                                 Identity_2 = tblUserDetails.Identity_2,
                                 WorkTitle = tblUserDetails.WorkTitle,
                                 WorkDescription = tblUserDetails.WorkDescription,
                                 WorkContact = tblUserDetails.WorkContact,
                                 ShopCompanyName = tblUserDetails.ShopCompanyName,
                                 VerificationComment = tblUserDetails.VerificationComment,
                                 VerificationDate = tblUserDetails.VerificationDate,
                                 IsVerified = tblUserDetails.IsVerified,
                                 IsTaskerActive = tblUserDetails.IsTaskerActive,
                                 IsUserActive = tblUserDetails.IsUserActive,
                                 IsPremiumUser = tblUserDetails.IsPremiumUser,
                                 CreatedOn = tblUserDetails.CreatedOn,
                                 UpdatedOn = tblUserDetails.UpdatedOn,
                                 IsTaskerActiveReject=tblUserDetails.IsTaskerActiveReject
                             }).ToList();

                    iFilteredTotal = dList.Count();

                    if (sSortDir_0 == "asc")
                        _dataList = dList.OrderBy(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                    else
                        _dataList = dList.OrderByDescending(orderingFunction).Skip(iDisplayStart).Take(iDisplayLength).ToList();
                    #endregion
                }
            }
            catch (Exception ex)
            {

            }
          
            return new JqueryUserDetailsDatatableResponse() { sEcho = sEcho, iTotalRecords = iTotal, iTotalDisplayRecords = iFilteredTotal, aaData = _dataList };
        }

        public async Task<GetVerificationDetailsByUserResponse> GetVerificationDetailsByUser(int id)
        {
           
           var dList = (from tblUserDetails in db.User_Details.AsEnumerable()
                     //join tblUserVerification_Details in db.UserVerification_Details.AsEnumerable() on tblUserDetails.id equals tblUserVerification_Details.UserId into tblUserDetailsVerification_Details
                     //from Uvd in tblUserDetailsVerification_Details.DefaultIfEmpty()
                     where tblUserDetails.DeleteFlag == false && tblUserDetails.IsUserActive == true && tblUserDetails.IsTaskerActive == false && 
                     tblUserDetails.IsTaskerActiveReject == false && tblUserDetails.id ==id
                     select new UserDetailsResponce
                     {
                         id = tblUserDetails.id,
                         UserId = tblUserDetails.id,
                         Name = tblUserDetails.Name,
                         PhoneNumber = tblUserDetails.PhoneNumber,
                         Email = tblUserDetails.Email,
                         Address = tblUserDetails.Address,
                         Identity_1 = tblUserDetails.Identity_1,
                         Identity_2 = tblUserDetails.Identity_2,
                         WorkTitle = tblUserDetails.WorkTitle,
                         WorkDescription = tblUserDetails.WorkDescription,
                         WorkContact = tblUserDetails.WorkContact,
                         ShopCompanyName = tblUserDetails.ShopCompanyName,
                         VerificationComment = tblUserDetails.VerificationComment,
                         VerificationDate = tblUserDetails.VerificationDate,
                         IsVerified = tblUserDetails.IsVerified,
                         IsTaskerActive = tblUserDetails.IsTaskerActive,
                         IsUserActive = tblUserDetails.IsUserActive,
                         IsPremiumUser = tblUserDetails.IsPremiumUser,
                         CreatedOn = tblUserDetails.CreatedOn,
                         UpdatedOn = tblUserDetails.UpdatedOn,
                         PremiumStartDate = tblUserDetails.PremiumStartDate,
                         PremiumEndDate=tblUserDetails.PremiumEndDate
                     }).ToList();
            return new GetVerificationDetailsByUserResponse() { dataList = dList };
        }

        public async Task<UpdateUserVerificationDetailsByUserResponse> UpdateVerificationDetailsForUser(VerifyUserDetailsRequest verifyUserDetailsRequest)
        {

           
            User_Details ud;
            List<EmailRecord> listEmailRecord= new List<EmailRecord>();
            try
            {
                int[] ids = verifyUserDetailsRequest.ids.Split(',').Select(int.Parse).ToArray();
                int[] userIds = verifyUserDetailsRequest.userids.Split(',').Select(int.Parse).ToArray();
                string subject = string.Empty;
                string DefaultComment = string.Empty;

                for (int i = 0; i < ids.Count(); i++)
                {
                    int id = ids[i];
                    int userId = userIds[i];

                    ud = db.User_Details.Where(a => a.id == userId).FirstOrDefault();
                    if (ud != null)
                    {
                        ud.IsTaskerActive = verifyUserDetailsRequest.IsVerified != null ? true : false;//If document verified then tasker request will active
                        ud.IsTaskerActiveReject = verifyUserDetailsRequest.IsTaskerActiveReject != null ? true : false;
                        ud.VerificationComment = verifyUserDetailsRequest.Comment;
                        ud.IsVerified = verifyUserDetailsRequest.IsVerified != null ? true : false;
                        ud.ReviewerUserId = verifyUserDetailsRequest.ReviewerUserId;
                        AddUserDetailsHistory(verifyUserDetailsRequest, ud.id);
                        db.SaveChanges();
                    }
                    if (verifyUserDetailsRequest.IsVerified==true)
                    {
                        subject = "TC Admin : Tasker Request Approved";
                        DefaultComment = string.IsNullOrEmpty( verifyUserDetailsRequest.Comment) ? "Congratulation, Tasker request has been approved.": verifyUserDetailsRequest.Comment;
                    }
                    if (verifyUserDetailsRequest.IsTaskerActiveReject == true)
                    {
                        subject = "TC Admin : Tasker Request Rejected";
                        DefaultComment = string.IsNullOrEmpty(verifyUserDetailsRequest.Comment) ? "Your tasker request has been Rejected. Please contact customer service." : verifyUserDetailsRequest.Comment;
                    }
                    subject = string.IsNullOrEmpty(subject) ? "TC Admin : Review Request" : subject;
                    DefaultComment = string.IsNullOrEmpty(DefaultComment) ? verifyUserDetailsRequest.Comment : DefaultComment;
                    listEmailRecord.Add(new EmailRecord() { Email=ud.Email, UserName=ud.Name,ReviewComment= DefaultComment, Subject= subject });
                }

                foreach (var emailRecord in listEmailRecord)
                {
                    EmailProfile._SendApiEmail(emailRecord.Email, emailRecord.ReviewComment, emailRecord.Subject);
                }
               

                return new UpdateUserVerificationDetailsByUserResponse() { id = 0, status = 0, Message = "Data saved successfully." };
            }
            catch (Exception ex)
            {
                return new UpdateUserVerificationDetailsByUserResponse() { id = 0, status = 1, Message = "Problem occure." };
            }
        }

        private void AddUserDetailsHistory(VerifyUserDetailsRequest verifyUserDetailsRequest, int userId)
        {
            User_Details_History udh = new User_Details_History()
            {                
                VerificationComment = verifyUserDetailsRequest.Comment,
                IsVerified = verifyUserDetailsRequest.IsVerified != null ? true : false,
                ReviewerUserId = verifyUserDetailsRequest.ReviewerUserId,
                User_Ref_Id = userId
            };
            db.User_Details_History.Add(udh);
        }
    }
}
