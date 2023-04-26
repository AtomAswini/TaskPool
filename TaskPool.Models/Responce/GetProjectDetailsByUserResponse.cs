using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class GetProjectDetailsByUserResponse
    {
        //public List<Project_Details> dataList { get; set; }
        public List<string> invalidReasons { get; set; }
        public List<ProjectDetailsResponce> dataList { get; set; }
    }
}
