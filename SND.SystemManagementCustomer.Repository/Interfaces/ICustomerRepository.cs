using System.Collections.Generic;
using SND.SystemManagementCustomer.Repository.Entities;
using SND.SystemManagementCustomer.Repository.Repositories.Interfaces;

namespace SND.SystemManagementCustomer.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<CustomerDTO>
    {
         IEnumerable<CustomerDTO> GetCustomersByParameters(string companyName, int? resellerId, decimal price);
    }
}