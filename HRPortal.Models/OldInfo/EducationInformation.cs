using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
   public  class EducationInformation
    {
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public DateTime GraduationDate { get; set; }
        public decimal GPA { get; set; }
        public string Awards { get; set; }

    }
}
