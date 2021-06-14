using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SND.SystemManagementCustomer.Presentation.Models
{
    public class SearchCustomerViewModel
    {
        [Display(Name = "CompanyName")]
        [StringLength(75)]
        public string CompanyName { get; set; }

        [Display(Name = "MinPrice")]
        public string MinPrice { get; set; }

        [Display(Name = "ResellerId")]
        public string SelectedResellerCode { get; set; }
        public IList<SelectListItem> Resellers { get; set; } = new List<SelectListItem>();
    }
}