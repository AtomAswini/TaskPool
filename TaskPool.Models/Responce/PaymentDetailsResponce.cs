using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class PaymentDetailsResponce
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentTransationId { get; set; }
        public string PaymentComment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentDateStr { get; set; }
        public string PaymentFromDate { get; set; }
        public string PaymentToDate { get; set; }
        public string ReviewComment { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int PackagePlanId { get; set; }
        public string PackageName { get; set; }
        public DateTime? PackageEndDate { get; set; }
        public string PackageEndDateStr { get; set; }

    }
}