using System.Collections.Generic;
using System.Linq;

namespace SND.SystemManagementCustomer.Presentation.Models
{
    public class CustomerViewModel
    {
        private IList<CustomerModel> _customers;

        public IReadOnlyCollection<CustomerModel> Customers
        {
            get
            {
                return _customers.ToArray();
            }
        }
        public SearchCustomerViewModel SearchCustomerViewModel { get; set; }

        public CustomerViewModel()
        {
            _customers = new List<CustomerModel>();
            SearchCustomerViewModel = new SearchCustomerViewModel();

        }

        public void AddCustomer(CustomerModel customer) =>
            _customers.Add(customer);
    }
}