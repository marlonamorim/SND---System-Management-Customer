using System.ComponentModel.DataAnnotations;

namespace SND.SystemManagementCustomer.Presentation.Models
{
    public class CustomerModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(75)]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State Prefix")]
        public string StatePrefix { get; set; }

        [Required]
        [Display(Name = "Order Quantity")]
        public int OrderQuantity { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}