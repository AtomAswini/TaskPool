﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TaskPool.Models
{
    public class GetCategoryResponce
    {
        public List<Project_Category> Categorys { get; set; }
        public List<string> invalidReasons { get; set; }
    }
}
