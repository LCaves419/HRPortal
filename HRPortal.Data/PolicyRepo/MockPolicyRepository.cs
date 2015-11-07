using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.PolicyRepo
{
    public class MockPolicyRepository : IPolicyRepository
    {
        private static List<PolicyInformation> _polInfo = new List<PolicyInformation>();
        //PolicyInformation pol = new PolicyInformation();

        private static bool isFirstLoad = false;

        public MockPolicyRepository()
        {
            if (!_polInfo.Any() && !isFirstLoad)
            {
                _polInfo.AddRange(new List<PolicyInformation>()
                {
                    new PolicyInformation {PolId = 1, CatName = "Attendance", PolicyName = "Tardy",
                            CreationDate = DateTime.Parse("12/02/2011"),
                            PolicyText = ("BLIUHEJLUHWLEUHOU FGHWEOPIUGHPEWOIUGHPOWUEHFLJD SHPOJOSH DPOIUWE GHOIUPEWHGPOUIW HEPOUIEW HOUVPWH BDPOJUPDGWHPOUWEGHGEOWPU HEPWOUG HWEPO U.")},


                    new PolicyInformation {PolId = 2, CatName = "Food", PolicyName = "Trash",
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
   //*********************Lara****************************************
   //*****************************************************************
        public List<Category> GetAllCategories()
        {
            List<Category> catList = new List<Category>();
            foreach (var p in _polInfo)
            {
                Category cats = new Category()
                {
                    CatId = p.PolId,
                   // CatId = p.Category.Distinct()
                    
                    CatName = p.CatName
                };
                catList.Add(cats);
            }
            return catList;
        }
  //****************************************************************
 //*****************************************************************

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

        //TODO: send back the Category Name not the number 

        public string  GetCatById(int id)
        {
            List<Category> allCats = GetAllCategories();
            var results = from c in allCats
                          where id == c.CatId
                         select c.CatName;
            var name = "";
            foreach (var c in results)
            {
                name = c;
            }

            
            return name;
        }
        //**********************HERE IT IS *************************************************
        //***********************************************************************

        //public List<string> GetCat()
        //{
        //    List<PolicyInformation> cats;
        //    cats = GetAll();

        //    //var results = from c in cats
        //    //    select c.Category;
        //    foreach (var c in cats)
        //    {
        //        List<string> cat = new List<string>();
        //        cat = c.Category;
        //    }

        //}
    }
}
