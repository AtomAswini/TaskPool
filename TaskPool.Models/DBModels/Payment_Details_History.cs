using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class Payment_Details_History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentTransationId { get; set; }
        public string PaymentComment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ReviewComment { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int PackagePlanId { get; set; }
        public DateTime? PackageEndDate { get; set; }
        public bool? DeleteFlag { get; set; }
        public int? ReviewerUserId { get; set; }
        public int? Payment_Ref_Id { get; set; }


    }
}
