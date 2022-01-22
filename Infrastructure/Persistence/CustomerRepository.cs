using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Domain.Entities;
using CustomerCruncher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCruncher.Infrastructure.Persistence
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {

            var customers = _dbContext.Customers
                .OrderBy(x => x.Id)
               .ToListAsync();
            return await customers;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var entity = await _dbContext.AddAsync(customer);
            return entity.Entity;
        }
    }
}