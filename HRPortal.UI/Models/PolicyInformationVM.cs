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
        // PolicyInformation pol = new PolicyInformation();
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

        //public PolicyInformation pol { get; set; }

        //public IEnumerable<SelectListItem> CategoryList { get; set; }// categoryVM

        [Display(Name = "Category List")]
        public string Category { get; set; }

        //public IEnumerable<SelectListItem> Categories
        //{
        //    get { return new SelectList(CategoryList,"Category");}
        //}


        //public class ViewModel
        //{
        //    private readonly List<IceCreamFlavor> _flavors;

        //    [Display(Name = "Favorite Flavor")]
        //    public int SelectedFlavorId { get; set; }

        //    public IEnumerable<SelectListItem> FlavorItems
        //    {
        //        get { return new SelectList(_flavors, "Id", "Name"); }
        //    }
        //}
    }
}
