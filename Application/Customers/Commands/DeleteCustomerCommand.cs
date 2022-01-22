using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int Id;
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repo;

        public DeleteCustomerCommandHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteCustomer(request.Id);
        }
    }
}
