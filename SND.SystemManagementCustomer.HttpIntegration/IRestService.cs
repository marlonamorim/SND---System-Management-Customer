using System.Net.Http;
using System.Threading.Tasks;

namespace SND.SystemManagementCustomer.HttpIntegration
{
    public interface IRestService
    {
         Task<HttpResponseMessage> GetAsync(string endpoint);
    }
}