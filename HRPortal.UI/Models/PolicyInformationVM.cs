using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HRPortal.UI.Models
{
    public class PolicyInformationVM
    {
        public PolicyInformationVM()
        {
            ListCat = new List<SelectListItem>();
        }

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
        public int CatId { get; set; }
        public string CatName { get; set; }
        public Category Category { get; set; }

        public List<SelectListItem> ListCat { get; set; }

        public void CreateCategoryList(List<Category> listOfCategories)
        {
            foreach (var s in listOfCategories)
            {
                var newItem = new SelectListItem();
                //newItem.Text = s.ListCat.ToString();
                newItem.Text = s.CatName;
                newItem.Value = s.CatId.ToString();// Do I need to Change this to Text ot vice versa??

                ListCat.Add(newItem);
            }
        }

        //*************************************************************
    }
}