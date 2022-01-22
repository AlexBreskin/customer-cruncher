using CustomerCruncher.Application.Common.Mappings;
using CustomerCruncher.Domain.Entities;
using System;

namespace CustomerCruncher.Application.Customers.Queries.GetCustomers
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
