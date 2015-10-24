using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data
{
    public class HRRepository : IApplicationRepository
    {
        private string _fileName = "DataFiles/applications.txt";

        public List<ApplicationInformation> GetAll()
        {
            List<ApplicationInformation> Resumes = new List<ApplicationInformation>();

            if (File.Exists(_fileName))
            {
                using (var reader = File.OpenText(_fileName))
                {
                    //read the header line
                    reader.ReadLine();

                    string inputLine;
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        var columns = inputLine.Split(',');
                        var appInfo = new ApplicationInformation()
                       // @PersonalInfo = new PersonalInformation();
                        //@EmploymentInfo = new EmploymentInformation();
                       // @EducationInfo = new EducationInformation();
                        {   
                            //Application                       
                            ResumeId = int.Parse(columns[0]),
                            Position = (columns[1]),
                            DesiredSalary = int.Parse(columns[2]),
                            DateOfApplication = DateTime.Parse(columns[3]),
                            //Employment
                            EmployerName = (columns[4]),
                            StartDate = DateTime.Parse(columns[5]),
                            EndDate = DateTime.Parse(columns[6]),
                            JobTitle = (columns[7]),
                            Responsibilities = (columns[8]),
                            //Personal
                            FirstName = (columns[9]),
                            LastName = (columns[10]),
                            StreetAddress = (columns[11]),
                            City = (columns[12]),
                            State = (columns[13]),
                            ZipCode = (columns[14]),
                            PhoneNumber = (columns[15]),
                            Email = (columns[16]),
                            //Education
                            Major = (columns[17]),
                            GraduationDate = DateTime.Parse(columns[18]),
                            GPA = (double.Parse(columns[19])),
                            Awards = (columns[20])
                        };

                        Resumes.Add(appInfo);
                    }
                }
            }

            return Resumes;
        }

        public void Add(ApplicationInformation newApplication)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newApplication.ResumeId = (GetAll().Any()) ? GetAll().Max(c => c.ResumeId) + 1 : 1;

            var applications = GetAll();
            applications.Add(newApplication);

            WriteFile(applications);
        }

        public void Delete(int id)
        {
            var applications = GetAll();
            applications.RemoveAll(c => c.ResumeId == id);

            WriteFile(applications);
        }

        public void Edit(ApplicationInformation ApplicationInfo)
        {
            var applications = GetAll();
            applications.RemoveAll(c => c.ResumeId == ApplicationInfo.ResumeId);
            applications.Add(ApplicationInfo);

            WriteFile(applications);
        }

        public ApplicationInformation GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.ResumeId == id);
        }

        private void WriteFile(List<ApplicationInformation> Apps)
        {
            using (var writer = File.CreateText(_fileName))
            {
                writer.WriteLine("Id,Position,DesiredSalary,DateOfApplication,EmployerName,StartDate,EndDate,JobTitle,Responsibilities,FirstName,LastName,StreetAddress,City,State,ZipCode,PhoneNumber,Email,Major,GraduationDate,GPA,Awards");

                foreach (ApplicationInformation app in Apps)
                {
                    writer.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}", 
                       app.ResumeId, app.Position, app.DesiredSalary, app.DateOfApplication,
                       app.EmployerName, app.StartDate, app.EndDate, 
                       app.JobTitle, app.Responsibilities,
                       app.FirstName, app.LastName, app.StreetAddress, 
                       app.City, app.State, app.ZipCode, app.PhoneNumber, app.Email,
                       app.Major, app.GraduationDate, app.GPA, app.Awards));
                }
            }
        }
    }
}

