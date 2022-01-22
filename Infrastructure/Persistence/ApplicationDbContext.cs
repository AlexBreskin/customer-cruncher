using CustomerCruncher.Application.Common.Interfaces;
using CustomerCruncher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerCruncher.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
