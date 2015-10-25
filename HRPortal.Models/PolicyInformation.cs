﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class PolicyInformation
    {
        public int CatId { get; set; }
        public int PolId { get; set; }
        public string Category { get; set; }
        public string PolicyName { get; set; }
        public string AttendancePolicy { get; set; }
        public string FoodPolicy { get; set; }
        public DateTime CreationDate { get; set; }
        public string PolicyText { get; set; }
    }
}