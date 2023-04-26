using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
   public class UpdateProjectDetailsByUserResponse
    {
        public int id { get; set; }
        public List<Project_Details> ProjectDetails { get; set; }       
        public List<string> invalidReasons { get; set; }
        public int? status { get; set; }
        public string Message { get; set; }
    }
}
