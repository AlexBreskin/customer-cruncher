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
using CustomerCruncher.Application.Customers.Queries.GetCustomersByName;

namespace CustomersCruncher.Application.UnitTests.Customers.Queries
{
    public class GetCustomersByNameRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockRepo;

        public GetCustomersByNameRequestHandlerTests()
        {
            _mockRepo = MockCustomerRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCustomersByNameShouldReturnTwo()
        {
            //Arrange
            var handler = new GetCustomersByNameHandler(_mockRepo.Object, _mapper);

            //Assert
            var result = await handler.Handle(new GetCustomersByNameQuery { searchParam = "J" }, CancellationToken.None);

            //Act
            result.Should().BeOfType<List<CustomerDto>>();
            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task GetCustomersByNameShouldReturnOne()
        {
            //Arrange
            var handler = new GetCustomersByNameHandler(_mockRepo.Object, _mapper);

            //Assert
            var result = await handler.Handle(new GetCustomersByNameQuery { searchParam = "John Doe" }, CancellationToken.None);

            //Act
            result.Should().BeOfType<List<CustomerDto>>();
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task GetCustomersByNameShouldReturnNone()
        {
            //Arrange
            var handler = new GetCustomersByNameHandler(_mockRepo.Object, _mapper);

            //Assert
            var result = await handler.Handle(new GetCustomersByNameQuery { searchParam = "Barry Spencer" }, CancellationToken.None);

            //Act
            result.Should().BeOfType<List<CustomerDto>>();
            result.Count.Should().Be(0);
        }
    }
}
