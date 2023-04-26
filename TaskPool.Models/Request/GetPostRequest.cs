using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models.Request
{
    public class GetPostRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
