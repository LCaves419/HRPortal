using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class ApplicationInformation
    {
        public int ResumeId { get; set; }
        public string Position { get; set; }
        public int DesiredSalary { get; set; }
        public DateTime DateOfApplication { get; set; }

        //Education
       // public EducationInformation EducationInfo { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public DateTime GraduationDate { get; set; }
        public double GPA { get; set; }
        public string Awards { get; set; }

        //Personal
        //public PersonalInformation PersonalInfo { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //Employment
        //public EmploymentInformation EmploymentInfo { get; set; }
        public string EmployerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string Responsibilities { get; set; }
    }
}
