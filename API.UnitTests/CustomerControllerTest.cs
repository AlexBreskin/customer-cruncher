using System;
using API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API.UnitTests
{
    public class CustomerControllerTest
    {
        private CustomerController controller;

        public CustomerControllerTest()
        {
            controller = new CustomerController();
        }

        [Fact]
        public void ShouldAddCustomerWithNameAndDateOfBirth()
        {
            string firstName = "John";
            string lastName = "Doe";
            DateTime dateOfBirth = new DateTime(1972, 1, 1);

            controller.AddCustomer(firstName, lastName, dateOfBirth).Should().BeEquivalentTo(new OkObjectResult(true));
        }
    }
}
