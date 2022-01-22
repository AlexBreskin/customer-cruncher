using AutoMapper;
using AutoMapper.QueryableExtensions;
using CustomerCruncher.Application.Common.Interfaces;
using CustomerCruncher.Application.Contracts.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<List<CustomerDto>>
    {
    }

    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public GetCustomersHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repo.GetAll();
            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
