using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class GetPostByUserResponce
    {
        public List<Project_Details> myPostDetails;
        public List<Project_Details> myFavouritesDetails;
        public List<string> invalidReasons { get; set; }
    }
}