using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class Tbl_Login_Manage
    {
        public int? Id { get; set; }
        public int? User_Mst_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public short? User_Type { get; set; }
        public bool Delete_Flag { get; set; }
    }
}
