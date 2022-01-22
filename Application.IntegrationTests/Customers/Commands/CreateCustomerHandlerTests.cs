using AutoMapper;
using CustomerCruncher.Application.Common.Interfaces;
using CustomerCruncher.Application.Common.Mappings;
using CustomerCruncher.Application.Customers.Queries.GetCustomers;
using CustomerCruncher.Application.UnitTests.Mocks;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Application.Customers.Commands.CreateCustomer;

namespace CustomersCruncher.Application.UnitTests.Customers.Commands
{
    public class CreateCustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockRepo;

        public CreateCustomerHandlerTests()
        {
            _mockRepo = MockCustomerRepository.GetRepository();
        }

        [Fact]
        public async Task CreateCustomerAndReturnCorrectId()
        {
            //Arrange
            var handler = new CreateCustomerCommandHandler(_mockRepo.Object);

            //Assert
            var result = await handler.Handle(new CreateCustomerCommand(), CancellationToken.None);

            //Act
            result.Should().Be(3);
        }

    }
}
