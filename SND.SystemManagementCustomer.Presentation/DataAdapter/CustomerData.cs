using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using SND.SystemManagementCustomer.Presentation.Binding.Options;
using SND.SystemManagementCustomer.Presentation.Models;
using SND.SystemManagementCustomer.Presentation.Services;
using SND.SystemManagementCustomer.Repository.Interfaces;

namespace SND.SystemManagementCustomer.Presentation.DataAdapter
{
    public class CustomerData
    {
        private readonly IOptions<ResellersApi> _settings;
        private readonly ResellerService _resellerService;
        private readonly ICustomerRepository _customerRepository;

        public CustomerData(IOptions<ResellersApi> settings,
            ResellerService resellerService,
            ICustomerRepository customerRepository)
        {
            _settings = settings;
            _resellerService = resellerService;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> AdapterCustomViewModel(CustomerViewModel model)
        {
            var resellers = await _resellerService.GetAllResellers(_settings.Value.BaseURL);

            var customers = _customerRepository.GetCustomersByParameters(model.SearchCustomerViewModel.CompanyName,
                string.IsNullOrEmpty(model.SearchCustomerViewModel.SelectedResellerCode) ? 0 : int.Parse(model.SearchCustomerViewModel.SelectedResellerCode),
                string.IsNullOrEmpty(model.SearchCustomerViewModel.MinPrice) ? 0 : decimal.Parse(model.SearchCustomerViewModel.MinPrice));

            var customerViewModel = new CustomerViewModel();

            customerViewModel.SearchCustomerViewModel.Resellers
                .Add(new SelectListItem { Value = "0", Text = "--Selecione--" });

            resellers
                .ToList()
                .ForEach(c => customerViewModel.SearchCustomerViewModel.Resellers
                        .Add(new SelectListItem { Value = c.Id.ToString(), Text = c.Name }));

            customers
                .ToList()
                .ForEach(c => customerViewModel.AddCustomer(new CustomerModel
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName,
                    CNPJ = c.CNPJ,
                    City = c.City,
                    StatePrefix = c.StatePrefix,
                    OrderQuantity = c.OrderQuantity,
                    Quantity = c.Quantity,
                    Price = c.Price
                }));

            return customerViewModel;
        }
    }
}