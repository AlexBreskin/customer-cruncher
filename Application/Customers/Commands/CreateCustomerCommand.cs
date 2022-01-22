using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _repo;

        public CreateCustomerCommandHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
            };
            await _repo.AddCustomer(customer);

            return customer.Id;
        }
    }
}
