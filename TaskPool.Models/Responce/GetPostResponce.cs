using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class GetPostResponce
    {
        public List<Project_Details> projectDetails;
        public List<string> invalidReasons { get; set; }
    }
}
