using AutoMapper;
using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Application.Customers.Queries.GetCustomers;
using CustomerCruncher.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Customers.Commands.EditCustomer
{
    public class EditCustomerCommand : IRequest<CustomerDto>
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
    }

    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public EditCustomerCommandHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
            };
            return _mapper.Map<CustomerDto>(await _repo.EditCustomer(customer)) ;
        }
    }
}
