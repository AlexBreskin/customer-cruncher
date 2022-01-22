using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Domain;
using CustomerCruncher.Domain.Entities;
using CustomerCruncher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class LeaveAllocationRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LeaveAllocationRepository(ApplicationDbContext dbContext) : base(dbContext)
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

    }
}