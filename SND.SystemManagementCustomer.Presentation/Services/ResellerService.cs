using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SND.SystemManagementCustomer.HttpIntegration;
using SND.SystemManagementCustomer.Presentation.Entities;

namespace SND.SystemManagementCustomer.Presentation.Services
{
    public class ResellerService
    {
        private readonly IRestService _restService;
        public ResellerService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<IEnumerable<ResellerEntitie>> GetAllResellers(string urlService)
        {

            var response = await _restService.GetAsync($"{urlService}");

            if (response.IsSuccessStatusCode && response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                var resultContentAsync = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResellerEntitie>>(resultContentAsync);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Error HTTP requesting service Resellers, details: ReturnCode:'{0}' ReturnName:'{1}' Url:'{2}'", response.StatusCode, response.ReasonPhrase, urlService));
            }
        }
    }
}