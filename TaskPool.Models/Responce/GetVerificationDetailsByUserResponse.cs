using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class GetVerificationDetailsByUserResponse
    {
        public List<UserDetailsResponce> dataList { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
