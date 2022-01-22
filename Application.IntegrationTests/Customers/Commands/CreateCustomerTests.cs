using CustomerCruncher.Application.Customers.Commands.CreateCustomer;
using CustomerCruncher.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.IntegrationTests.Commands
{
    public class CreateCustomerTests
    {
        //[Fact]
        //public async Task ShouldCreateCustomer()
        //{
        //    var firstname = "John";
        //    var lastname = "Doe";
        //    var DateOfBirth = new DateTime(1972, 3, 4);


        //    var command = new CreateCustomerCommand
        //    { 
        //        FirstName = firstname,
        //        LastName = lastname,
        //        DateOfBirth = DateOfBirth
        //    };

        //    var id = await SendAsync(command);
        //    var customer = await FindAsync<Customer>(id);

        //    customer.Should().NotBeNull();
        //    customer.FirstName.Should().Be(firstname);
        //    customer.LastName.Should().Be(lastname);
        //    customer.DateOfBirth.Should().Be(DateOfBirth);

        //}
    }
}
