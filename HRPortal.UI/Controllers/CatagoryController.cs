using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data.PolicyRepo;
using HRPortal.Models;
using HRPortal.UI.Models;

namespace HRPortal.UI.Controllers
{
    public class CatagoryController : Controller
    {
        // GET: Catagory
        public ActionResult Index()
        {
            var repo = PolicyRepositoryFactory.CreatePolicyRepository();
            var cats = repo.GetAllCategories();

            return View(cats);
        }

        public ActionResult RequestForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestFormPost()
        {
            CategoryVM p = new CategoryVM();

            p.Category.CatName = (Request.Form["Category Name"]);
          

            return View("Result", p);
        }
      


    }
}