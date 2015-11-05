using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;

namespace HRPortal.UI.Models
{
    public class PolicyInformationVM
    {
        [Display(Name = "Policy Id")]
        public string PolId { get; set; }

       
        [Required]
        [Display(Name = "Policy Name")]
        public string PolicyName { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Policy Text")]
        public string PolicyText { get; set; }


        //****************************************************
        public Category Category { get; set; }
        public List<SelectListItem> ListCat { get; set; }

        public List<Category> CreateCategoryList(List<Category> listOfCategories)
        {
            ListCat = new List<SelectListItem>();

            foreach (var s in listOfCategories)
            {
                var newItem = new SelectListItem();
                //newItem.Text = s.ListCat.ToString();
                newItem.Value = s.CatName;
                newItem.Value = s.CatId.ToString();
                
                ListCat.Add(newItem);
            }
        }
        //*************************************************************

        
    }
}
