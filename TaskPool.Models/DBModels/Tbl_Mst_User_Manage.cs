using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class Tbl_Mst_User_Manage
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Address { get; set; }
        public string Email_Id { get; set; }
        public bool Delete_Flag { get; set; }
        public short Created_By { get; set; }
        public DateTime? Created_On { get; set; }
        public short Modified_By { get; set; }
        public DateTime? Modified_On { get; set; }
    }
}
