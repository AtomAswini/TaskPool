﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class AddProjectResponce
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
