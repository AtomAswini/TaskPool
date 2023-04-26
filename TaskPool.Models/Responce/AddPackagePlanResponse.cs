using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
   public class AddPackagePlanResponse
    {
        public int id { get; set; }
        public string PackageName { get; set; }
        public decimal? Price { get; set; }
        public int? Days { get; set; }
        public string ids { get; set; }
        public List<string> invalidReasons { get; set; }
        public int? status { get; set; }
        public string Message { get; set; }
    }
}
