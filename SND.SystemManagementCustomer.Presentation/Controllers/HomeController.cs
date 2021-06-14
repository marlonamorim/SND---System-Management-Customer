using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SND.SystemManagementCustomer.HttpIntegration;
using SND.SystemManagementCustomer.Presentation.Binding.Options;
using SND.SystemManagementCustomer.Presentation.DataAdapter;
using SND.SystemManagementCustomer.Presentation.Models;
using SND.SystemManagementCustomer.Presentation.Services;
using SND.SystemManagementCustomer.Repository.Interfaces;

namespace SND.SystemManagementCustomer.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ResellerService _resellerService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOptions<ResellersApi> _settings;

        public HomeController(ILogger<HomeController> logger,
            IOptions<ResellersApi> settings,
            [FromServices] ResellerService resellerService,
            [FromServices] ICustomerRepository customerRepository)
        {
            _logger = logger;
            _resellerService = resellerService;
            _customerRepository = customerRepository;
            _settings = settings;
        }

        public async Task<IActionResult> Index(CustomerViewModel model)
        {
            var customerData = new CustomerData(_settings, _resellerService, _customerRepository);

            var payload = await customerData.AdapterCustomViewModel(model);
            
            return View(payload);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
