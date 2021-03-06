﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortal.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // retrieve all the contacts
            var repo = Factory.CreateApplicationRepository();
            var applications = repo.GetAll();

            return View(applications);
        }

        public ActionResult Edit(int id)
        {
            // get the contact from the repo
            var repo = Factory.CreateApplicationRepository();
            ApplicationInformation  app = repo.GetById(id);

            return View(app);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationInformation application)
        {
            // edit the contact in the repo
            var repo = Factory.CreateApplicationRepository();
            repo.Edit(application);

            return RedirectToAction("AppReceived");
        }

        [HttpPost]
        public ActionResult DeleteApplication(int id)
        {
            // delete the contact from the repo
            var repo = Factory.CreateApplicationRepository();
            repo.Delete(id);

            // get the contacts and go to the Index
            //var contacts = repo.GetAll();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ApplicationInformation model)
        {
            // create a contact
            var a = new ApplicationInformation();

            // get the data from the input fields
            //Personal Information
            a.FirstName = Request.Form["FirstName"];
            a.LastName = Request.Form["LastName"];
            a.PhoneNumber = Request.Form["PhoneNumber"];
            a.Email = Request.Form["Email"];
            a.StreetAddress = Request.Form["StreetAddress"];
            a.State = Request.Form["State"];
            a.City = Request.Form["City"];
            a.ZipCode = Request.Form["ZipCode"];

            //Application
            a.DesiredSalary = int.Parse(Request.Form["DesiredSalary"]);
            a.Position = Request.Form["Position"];
            a.JobTitle = Request.Form["JobTitle"];
            a.SchoolName = Request.Form["SchoolName"];
            a.Responsibilities = Request.Form["Responsibilities"];
            a.StartDate = DateTime.Parse(Request.Form["StartDate"]);
            a.EndDate = DateTime.Parse(Request.Form["EndDate"]);
            a.Awards = Request.Form["Awards"];
            a.DateOfApplication = DateTime.Parse(Request.Form["DateOfApplication"]);
            a.EmployerName = Request.Form["EmployerName"];
            a.GPA = double.Parse(Request.Form["GPA"]);
            a.GraduationDate = DateTime.Parse(Request.Form["GraduationDate"]);
            a.Major = Request.Form["Major"];
            
            // create our application in the repository
            var repo = Factory.CreateApplicationRepository();

            // add the application
            repo.Add(a);

            return RedirectToAction("Edit");
            //return View(model);
        }

        // Directs to App with Navbar.
        public ActionResult CreateWNav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWNav(ApplicationInformation model)
        {
            // create a contact
            var a = new ApplicationInformation();

            // get the data from the input fields
            //Personal Information
            a.FirstName = Request.Form["FirstName"];
            a.LastName = Request.Form["LastName"];
            a.PhoneNumber = Request.Form["PhoneNumber"];
            a.Email = Request.Form["Email"];
            a.StreetAddress = Request.Form["StreetAddress"];
            a.State = Request.Form["State"];
            a.City = Request.Form["City"];
            a.ZipCode = Request.Form["ZipCode"];

            //Application
            a.DesiredSalary = int.Parse(Request.Form["DesiredSalary"]);
            a.Position = Request.Form["Position"];
            a.JobTitle = Request.Form["JobTitle"];
            a.SchoolName = Request.Form["SchoolName"];
            a.Responsibilities = Request.Form["Responsibilities"];
            a.StartDate = DateTime.Parse(Request.Form["StartDate"]);
            a.EndDate = DateTime.Parse(Request.Form["EndDate"]);
            a.Awards = Request.Form["Awards"];
            a.DateOfApplication = DateTime.Parse(Request.Form["DateOfApplication"]);
            a.EmployerName = Request.Form["EmployerName"];
            a.GPA = double.Parse(Request.Form["GPA"]);
            a.GraduationDate = DateTime.Parse(Request.Form["GraduationDate"]);
            a.Major = Request.Form["Major"];

            // create our application in the repository
            var repo = Factory.CreateApplicationRepository();

            // add the application
            repo.Add(a);

            return RedirectToAction("AppReceived");
            //return View(model);
        }
        
        public ActionResult AppReceived()
        {
            return View("AppReceived");
        }
    }
}