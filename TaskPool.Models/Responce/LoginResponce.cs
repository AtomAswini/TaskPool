﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class LoginResponce
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public string phoneNumber { get; set; } 
        public string Email { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
