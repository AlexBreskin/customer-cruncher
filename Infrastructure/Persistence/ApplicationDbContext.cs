using CustomerCruncher.Application.Common.Interfaces;
using CustomerCruncher.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerCruncher.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<Customer> Customers { get; set; }
    }

}
