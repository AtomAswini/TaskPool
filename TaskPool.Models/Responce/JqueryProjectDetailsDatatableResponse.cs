﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPool.Models
{
    public class JqueryProjectDetailsDatatableResponse
    {
        public int sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public List<ProjectDetailsResponce> aaData { get; set; }

    }
}
