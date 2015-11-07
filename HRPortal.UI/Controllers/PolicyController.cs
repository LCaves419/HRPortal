using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Data.PolicyRepo;
using HRPortal.Models;
using HRPortal.UI.Models;

namespace HRPortal.UI.Controllers
{
    public class PolicyController : Controller
    {
//************************************************************
//************************************************************

        // GET: Policy
        public ActionResult Index()
        {
            // retrieve all the contacts
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            //get policies from repo
            var policies = repo.GetAll();

            return View(policies);
        }

        public ActionResult Edit(int id)
        {
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            var pol = repo.GetById(id);

            return View(pol);
        }

        [HttpPost]
        public ActionResult Edit(PolicyInformation policy)
        {
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            repo.Edit(policy);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            //var pol = repo.GetById(id);
            repo.Delete(id);

            return RedirectToAction("Index");
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PolicyInformation model)
        {
            // create a contact
            //var a = new PolicyInformation();

            //// get the data from the input fields
            ////a.PolId = int.Parse(Request.Form["LastName"]);
            //a.Category= Request.Form["Category"];
            //a.PolicyName = Request.Form["PolicyName"];
            //a.CreationDate = DateTime.Parse(Request.Form["CreationDate"]);
            //a.PolicyText = Request.Form["PolicyText"];
           
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            // get the Cat ID *********************************
            //TODO: Call GETCATBYID to get the name of the category and add it to the model
            var catNum = 0;
            if (model.CatName == "Food" || model.CatName == "Attendance")
            {
                catNum = model.CatId;
            }
            
            model.CatName = repo.GetCatById(catNum);

            // add the policy
            repo.Add(model);

            return RedirectToAction("Index");
            //return View(model);
        }

      
    }
}