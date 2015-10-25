﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Data.PolicyRepo;
using HRPortal.Models;

namespace HRPortal.UI.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            // retrieve all the contacts
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
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
        public ActionResult EditPolicy(PolicyInformation policy)
        {
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            repo.Edit(policy);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeletePolicy(int id)
        {
           
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
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
            var a = new PolicyInformation();

            // get the data from the input fields
            a.CatId = int.Parse(Request.Form["CatId"]);
            a.PolId = int.Parse(Request.Form["LastName"]);
            a.Category= Request.Form["Category"];
            a.PolicyName = Request.Form["PolicyName"];
            a.AttendancePolicy = Request.Form["AttendencePolicy"];
            a.FoodPolicy = Request.Form["FoodPolicy"];
            a.CreationDate = DateTime.Parse(Request.Form["CreationDate"]);
            a.PolicyText = Request.Form["PolicyText"];
           
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();

            // add the policy
            repo.Add(a);

            return RedirectToAction("Index");
            //return View(model);
        }
    }
}