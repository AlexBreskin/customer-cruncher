using CustomerCruncher.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Contracts.Persistence
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers();
        public Task<Customer> AddCustomer(Customer customer);

    }
}
