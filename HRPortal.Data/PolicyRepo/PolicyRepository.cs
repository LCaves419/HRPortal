using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.PolicyRepo
{
    public class PolicyRepository : IPolicyRepository
    {
        private string _policyFileName = "DataFiles/policies.txt";

        PolicyInformation pol = new PolicyInformation();

        public List<PolicyInformation> GetAll()
        {
            List<PolicyInformation> Policies = new List<PolicyInformation>();

            if (File.Exists(_policyFileName))
            {
                using (var reader = File.OpenText(_policyFileName))
                {
                    //read the header line
                    reader.ReadLine();

                    string inputLine;
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        var columns = inputLine.Split(',');
                        var policyInfo = new PolicyInformation()
                        {
                            //Application
                            CatId = int.Parse(columns[0]),
                            PolId = int.Parse(columns[1]),
                            Category = (columns[2]),
                            PolicyName = (columns[3]),
                            AttendancePolicy = (columns[4]),
                            FoodPolicy = (columns[5]),
                            CreationDate = DateTime.Parse(columns[6]),
                            PolicyText = (columns[7]),
                        };

                        Policies.Add(policyInfo);
                    }
                }
            }

            return Policies;
        }

        public void Add(PolicyInformation newPolicy)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newPolicy.PolId = (GetAll().Any()) ? GetAll().Max(c => c.PolId) + 1 : 1;

            var policies = GetAll();
            policies.Add(newPolicy);

            WriteFile(policies);
        }

        public void Delete(int id)
        {
            var policies = GetAll();
            policies.RemoveAll(c => c.PolId == id);

            WriteFile(policies);
        }

        public void Edit(PolicyInformation PolicyInfo)
        {
            var policies = GetAll();
            policies.RemoveAll(c => c.PolId == PolicyInfo.PolId);
            policies.Add(PolicyInfo);

            WriteFile(policies);
        }

        public PolicyInformation GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.PolId == id);
        }

        private void WriteFile(List<PolicyInformation> Policies)
        {
            using (var writer = File.CreateText(_policyFileName))
            {
                writer.WriteLine("CategoryID, PolicyID, Category, PolicyName, AttendancePolicy, FoodPolicy, CreationDate, PolicyText");

                foreach (PolicyInformation pol in Policies)
                {
                    writer.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                       pol.CatId, pol.PolId, pol.Category, pol.PolicyName, pol.AttendancePolicy, pol.FoodPolicy,
                       pol.CreationDate, pol.PolicyText));
                }
            }
        }
    }
}
