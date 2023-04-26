using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
   public class UpdatePaymentDetailsByUserRequest
    {
        public int id { get; set; }
        public string Comment { get; set; }
        public string ids { get; set; }
        public int ReviewerUserId { get; set; }
    }
}
