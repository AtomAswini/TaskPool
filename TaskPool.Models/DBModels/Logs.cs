using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class Logs
    {
        public int id { get; set; }
        public string ip_address { get; set; }
        public int Userid { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public string error_message { get; set; }
        public int http_response_code { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EndPointName { get; set; }

    }
}
