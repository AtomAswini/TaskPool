using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class VerifyUserDetailsRequest
    {
        public int UserId { get; set; }
        public string Comment { get; set; }
        public bool? IsVerified { get; set; }
        public string ids { get; set; }
        public string userids { get; set; }
        public string isVerifieds { get; set; }
        public int ReviewerUserId { get; set; }
        public bool? IsTaskerActiveReject { get; set; }
    }
}
