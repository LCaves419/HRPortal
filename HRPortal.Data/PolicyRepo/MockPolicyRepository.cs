using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.PolicyRepo
{
    public class MockPolicyRepository : IPolicyRepository
    {
        private static List<PolicyInformation> _polInfo = new List<PolicyInformation>();
        PolicyInformation pol = new PolicyInformation();

        private static bool isFirstLoad = false;

        public MockPolicyRepository()
        {
            if (!_polInfo.Any() && !isFirstLoad)
            {
                _polInfo.AddRange(new List<PolicyInformation>()
                {
                    new PolicyInformation {PolId = 1, Category = "Attendance", PolicyName = "Tardy",
                            CreationDate = DateTime.Parse("12/02/2011"),
                            PolicyText = ("BLIUHEJLUHWLEUHOU FGHWEOPIUGHPEWOIUGHPOWUEHFLJD SHPOJOSH DPOIUWE GHOIUPEWHGPOUIW HEPOUIEW HOUVPWH BDPOJUPDGWHPOUWEGHGEOWPU HEPWOUG HWEPO U.")},


                    new PolicyInformation {PolId = 2, Category = "Food", PolicyName = "Trash",
                            CreationDate = DateTime.Parse("12/02/2011"),
                            PolicyText = ("BLIUHEJLUHWLEUHOU FGHWEOPIUGHPEWOIUGHPOWUEHFLJD SHPOJOSH DPOIUWE GHOIUPEWHGPOUIW HEPOUIEW HOUVPWH BDPOJUPDGWHPOUWEGHGEOWPU HEPWOUG HWEPO U.")}
                                  });
                isFirstLoad = true;
            }
        }

        public List<PolicyInformation> GetAll()
        {
            return _polInfo;
        } 

        public void Add(PolicyInformation newPolicy)
        {
            // ternary operator is saying:
            // if there are any contacts return the max contact id and add 1 to set our new contact id
            // else set to 1
            newPolicy.PolId = (GetAll().Any()) ? GetAll().Max(c => c.PolId) + 1 : 1;

            _polInfo.Add(newPolicy);
        }

        public void Delete(int id)
        {
            _polInfo.RemoveAll(p => p.PolId == id);
        }

        public void Edit(PolicyInformation PolicyInfo)
        {
            Delete(PolicyInfo.PolId);
            _polInfo.Add(PolicyInfo);
        }

        public PolicyInformation GetById(int id)
        {
            return _polInfo.FirstOrDefault(p => p.PolId == id);
        }
    }
}
