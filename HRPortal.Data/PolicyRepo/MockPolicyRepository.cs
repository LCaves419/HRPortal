﻿using System;
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
                            PolicyText = ("Bacon ipsum dolor amet hamburger andouille ham hock porchetta kielbasa doner short ribs. Frankfurter turducken drumstick, ball tip cow sirloin salami tri-tip short ribs chicken pork belly boudin beef ribs. Picanha t-bone short loin meatloaf alcatra, jowl frankfurter kevin. Pork chop tri-tip chicken, jowl jerky cow swine pork loin spare ribs. Sirloin kevin beef short loin ham.")},


                    new PolicyInformation {PolId = 2, CatName = "Food", PolicyName = "Trash",
                            CreationDate = DateTime.Parse("12/02/2011"),
                            PolicyText = ("Chuck t-bone short loin, pork cow tri-tip filet mignon pork loin pork chop tongue pig. T-bone leberkas doner, pancetta kevin bacon filet mignon ham hock biltong andouille drumstick hamburger shank spare ribs. Frankfurter ham hock turducken pork chop filet mignon meatloaf boudin andouille. Tail venison porchetta chicken. Kevin tri-tip fatback ball tip. Pig venison biltong ham shankle salami tenderloin tongue flank fatback strip steak kevin. Rump frankfurter landjaeger ham hock, t-bone biltong meatloaf pork belly boudin bacon swine.")}
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

        //Need to send back CatName, not ID.
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
    }
}
