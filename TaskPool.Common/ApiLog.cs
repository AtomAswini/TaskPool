using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Common
{
    public class ApiLog
    {
        public long Id { get; set; }
        public string IpAddress { get; set; }
        public string Response { get; set; }
        public string Request { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ElapsedTime { get; set; }
        public string ErrorMessage { get; set; }
        public int UserId { get; set; }
        public int HttpResponseCode { get; set; }
        public string EndPointName { get; set; }
    }
}
