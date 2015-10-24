using System;
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
            // retrieve the contact id we passed in
            //int contactId = int.Parse(RouteData.Values["id"].ToString());

            // get the contact from the repo
            var repo = Factory.CreateApplicationRepository();
            var app = repo.GetById(id);

            return View(app);
        }

        [HttpPost]
        public ActionResult EditApplication(ApplicationInformation application)
        {
            //// create a new contact
            //var c = new Contact();

            //// set the values from the form
            //c.Name = Request.Form["Name"];
            //c.PhoneNumber = Request.Form["PhoneNumber"];
            //c.ContactID = int.Parse(Request.Form["ContactID"]);

            // edit the contact in the repo
            var repo = Factory.CreateApplicationRepository();
            repo.Edit(application);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteApplication(int id)
        {
            // get the id that we passed in
            //int contactID = int.Parse(Request.Form["ContactID"]);

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

            return RedirectToAction("Index");
            //return View(model);
        }
    }
}