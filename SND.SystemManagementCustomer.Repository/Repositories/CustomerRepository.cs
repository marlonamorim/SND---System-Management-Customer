using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SND.SystemManagementCustomer.Repository.Entities;
using SND.SystemManagementCustomer.Repository.Interfaces;

namespace SND.SystemManagementCustomer.Repository.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(SystemManagementContext systemManagementContext) : base(systemManagementContext)
        {
        }

        public IEnumerable<CustomerDTO> GetCustomersByParameters(string companyName, int? resellerId, decimal price)
        {
            var parameters = new List<SqlParameter> {
                new SqlParameter("@ResellerId", "169644"),
                new SqlParameter("@CompanyName", "169644"),
                new SqlParameter("@MinPrice", "0.01")
            };

            return ExecuteStoreProcedure($"EXEC ShowCustomers '{resellerId}', '{companyName}', '{price}'");
        }
    }
}