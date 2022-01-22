using CustomerCruncher.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerCruncher.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}
