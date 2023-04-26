using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class User_Details
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identity_1 { get; set; }
        public string Identity_2 { get; set; }
        public string WorkTitle { get; set; }
        public string WorkDescription { get; set; }
        public string WorkContact { get; set; }
        public string ShopCompanyName { get; set; }
        public string ProfilePhoto { get; set; }
        public bool? IsTaskerActive { get; set; }
        public bool? IsUserActive { get; set; }
        public bool? IsPremiumUser { get; set; }
        public bool? DeleteFlag { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? PremiumStartDate { get; set; }
        public DateTime? PremiumEndDate { get; set; }
        public bool? IsTaskerActiveReject { get; set; }
        public string VerificationComment { get; set; }
        public DateTime? VerificationDate { get; set; }
        public bool? IsVerified { get; set; }
        public int? ReviewerUserId { get; set; }
    }
}
