using CustomerCruncher.Application.Common.Interfaces;
using CustomerCruncher.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CustomerCruncher.Application.Contracts.Persistence;

namespace CustomerCruncher.Application.UnitTests.Mocks
{
    public static class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetRepository()
        {
            var customers = new List<Customer>
            { 
                new Customer { 
                    Id = 1, 
                    FirstName = "John", 
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1972, 3, 4)
                },
                new Customer {
                    Id = 2,
                    FirstName = "Jerry",
                    LastName = "Adams",
                    DateOfBirth = new DateTime(1982, 3, 4)
                },
            };

            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(r => r.GetAllCustomers()).ReturnsAsync(customers);

            mockRepo.Setup(r => r.AddCustomer(It.IsAny<Customer>())).ReturnsAsync((Customer customer) =>
            {
                customer.Id = customers.Max(x => x.Id) + 1;
                customers.Add(customer);
                return customer;
            });

            mockRepo.Setup(r => r.EditCustomer(It.IsAny<Customer>())).ReturnsAsync((Customer customer) =>
            {
                if (customers.Any(x => x.Id == customer.Id))
                    return customer;
                return null;
            });

            mockRepo.Setup(r => r.DeleteCustomer(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                if (customers.Any(x => x.Id == Id))
                    return true;
                return false;
            });

            return mockRepo;
        }

    }
}
