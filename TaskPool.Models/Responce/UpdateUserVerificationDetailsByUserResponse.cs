using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
   public class UpdateUserVerificationDetailsByUserResponse
    {
        public int id { get; set; }
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
        public List<string> invalidReasons { get; set; }
        public int? status { get; set; }
        public string Message { get; set; }
    }
}
