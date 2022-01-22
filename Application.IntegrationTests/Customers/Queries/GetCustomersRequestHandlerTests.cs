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

namespace CustomersCruncher.Application.UnitTests.Customers.Queries
{
    public class GetCustomersRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockRepo;

        public GetCustomersRequestHandlerTests()
        {
            _mockRepo = MockCustomerRepository.GetRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCustomersListTest()
        {
            //Arrange
            var handler = new GetCustomersHandler(_mockRepo.Object, _mapper);

            //Assert
            var result = await handler.Handle(new GetCustomersQuery(), CancellationToken.None);

            //Act
            result.Should().BeOfType<List<CustomerDto>>();
            result.Count.Should().Be(2);
        }

    }
}
