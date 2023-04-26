using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class GetUserByUserNamePasswordResponce
    {
        public Tbl_Login_Manage user { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
