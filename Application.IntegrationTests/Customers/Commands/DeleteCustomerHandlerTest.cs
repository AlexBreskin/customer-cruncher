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
using CustomerCruncher.Application.Customers.Commands.EditCustomer;
using System;
using CustomerCruncher.Application.Customers.Commands.DeleteCustomer;

namespace CustomersCruncher.Application.UnitTests.Customers.Commands
{
    public class DeleteCustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockRepo;
        private readonly IMapper _mapper;

        public DeleteCustomerHandlerTests()
        {
            _mockRepo = MockCustomerRepository.GetRepository();
        }

        [Fact]
        public async Task DeleteCustomerWithCorrectId()
        {
            //Arrange
            var handler = new DeleteCustomerCommandHandler(_mockRepo.Object);
            var command = new DeleteCustomerCommand
            {
                Id = 1
            };

            //Assert
            var result = await handler.Handle(command, CancellationToken.None);

            //Act
            result.Should().Be(true);
        }

        [Fact]
        public async Task DeleteCustomerWithIncorrectId()
        {
            //Arrange
            var handler = new DeleteCustomerCommandHandler(_mockRepo.Object);
            var command = new DeleteCustomerCommand
            {
                Id = 5
            };

            //Assert
            var result = await handler.Handle(command, CancellationToken.None);

            //Act
            result.Should().Be(false);
        }
    }
}
