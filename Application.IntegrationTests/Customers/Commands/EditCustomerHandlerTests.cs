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

namespace CustomersCruncher.Application.UnitTests.Customers.Queries
{
    public class EditCustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockRepo;
        private readonly IMapper _mapper;

        public EditCustomerHandlerTests()
        {
            _mockRepo = MockCustomerRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task EditCustomerAndReturnCorrectId()
        {
            //Arrange
            var handler = new EditCustomerCommandHandler(_mockRepo.Object, _mapper);
            var command = new EditCustomerCommand
            { 
                Id = 1,
                FirstName = "Johnny",
                LastName = "Wick",
                DateOfBirth = new DateTime(1982, 2, 2)
            };


            //Assert
            var result = await handler.Handle(command, CancellationToken.None);

            //Act
            result.Should().BeEquivalentTo(new CustomerDto
            {
                Id = 1,
                FirstName = "Johnny",
                LastName = "Wick",
                DateOfBirth = new DateTime(1982, 2, 2)
            });
        }

        [Fact]
        public async Task EditCustomerThatDoesntExistAndReturnNull()
        {
            //Arrange
            var handler = new EditCustomerCommandHandler(_mockRepo.Object, _mapper);
            var command = new EditCustomerCommand
            {
                Id = 5,
                FirstName = "Barry",
                LastName = "Jones",
                DateOfBirth = new DateTime(1983, 2, 3)
            };

            //Assert
            var result = await handler.Handle(command, CancellationToken.None);

            //Act
            result.Should().BeNull();
        }
    }
}
