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
            _dbContext.SaveChanges();
            return entity.Entity;
        }

        public async Task<Customer> EditCustomer(Customer customer)
        {
            var originalCustomer = await _dbContext.Customers.Where(q => q.Id == customer.Id).FirstOrDefaultAsync();

            if (originalCustomer == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(customer.FirstName))
                originalCustomer.FirstName = customer.FirstName;
            if (!string.IsNullOrEmpty(customer.LastName))
                originalCustomer.LastName = customer.LastName;

            originalCustomer.DateOfBirth = customer.DateOfBirth;

            _dbContext.Entry(originalCustomer).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return originalCustomer;
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            var originalCustomer = await _dbContext.Customers.Where(q => q.Id == Id).FirstOrDefaultAsync();

            if (originalCustomer == null)
            {
                return false;
            }

            _dbContext.Entry(originalCustomer).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return true;
        }


        public async Task<List<Customer>> GetCustomersByName(string searchParam)
        {
            var customers = _dbContext.Customers
                .Where(x => (x.FirstName + " " + x.LastName).Contains(searchParam))
                .OrderBy(x => x.Id)
               .ToListAsync();

            return await customers;
        }
    }
}