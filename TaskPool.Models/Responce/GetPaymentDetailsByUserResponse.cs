using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class GetPaymentDetailsByUserResponse
    {
        public List<Payment_Details> dataList { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
