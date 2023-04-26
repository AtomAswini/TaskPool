using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class VerifyProjectDetailsRequest
    {
        public int id { get; set; }
        public string Comment { get; set; }
        public string ids { get; set; }
        public int ReviewerUserId { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsActiveReject { get; set; }
    }
}
