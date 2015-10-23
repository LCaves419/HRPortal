using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data
{
    public class MockHRRepository : IApplicationRepository
    {
        //ApplicationInformation AppInfo = new ApplicationInformation();
        private static List<ApplicationInformation> _appInfo = new List<ApplicationInformation>();
        ApplicationInformation app = new ApplicationInformation();        
        
        private static bool isFirstLoad = false;

        public MockHRRepository()
        {             
            if (!_appInfo.Any() && !isFirstLoad)
            {
                _appInfo.AddRange(new List<ApplicationInformation>()
                {
                    new ApplicationInformation {ResumeId = 1, Position = "Programmer", DesiredSalary = 80000,
                        DateOfApplication = DateTime.Parse("10/21/2015"), EmployerName = "NASA",
                        StartDate = DateTime.Parse("01/01/1994"), EndDate = DateTime.Parse("01/01/2010"), JobTitle = "Sales", Responsibilities = "SOld Stuff",
                        Firstname = "Bob", LastName = "Smith", StreetAddress = "103 MAin St", City = "Huntsville", State = "AL", Zipcode = "35016",
                        PhoneNumber = "586-4681", Email =  "Bob@gmail.com", Major = "Information Tech", GraduationDate = DateTime.Parse("05/21/1993"),
                        GPA = 3.9, Awards = " I am a smart Guy" },


                    new ApplicationInformation {ResumeId = 2, Position = "Sales", DesiredSalary = 80000,
                        DateOfApplication = DateTime.Parse("10/21/2015"), EmployerName = "NASA",
                        StartDate = DateTime.Parse("01/01/1994"), EndDate = DateTime.Parse("01/01/2010"), JobTitle = "Sales", Responsibilities = "SOld Stuff",
                        Firstname = "Bob", LastName = "Smith", StreetAddress = "103 MAin St", City = "Huntsville", State = "AL", Zipcode = "35016",
                        PhoneNumber = "586-4681", Email =  "Bob@gmail.com", Major = "Information Tech", GraduationDate = DateTime.Parse("05/21/1993"),
                        GPA = 3.9, Awards = " I am a smart Guy"}
                                  });
                isFirstLoad = true;
            }
        }

        public List<ApplicationInformation> GetAll()
        {
            return _appInfo;
        }

        public void Add(ApplicationInformation newApp)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newApp.ResumeId = (_appInfo.Any()) ? _appInfo.Max(c => c.ResumeId) + 1 : 1;

            _appInfo.Add(newApp);
        }

        public void Delete(int id)
        {
            _appInfo.RemoveAll(c => c.ResumeId == id);
        }

        public void Edit(ApplicationInformation app)
        {
            Delete(app.ResumeId);
            _appInfo.Add(app);
        }

        public ApplicationInformation GetById(int id)
        {
            return _appInfo.FirstOrDefault(c => c.ResumeId == id);
        }
    }
}
