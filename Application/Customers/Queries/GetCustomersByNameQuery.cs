using AutoMapper;
using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Application.Customers.Queries.GetCustomers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Customers.Queries.GetCustomersByName
{
    public class GetCustomersByNameQuery : IRequest<List<CustomerDto>>
    {
        public string searchParam;
    }

    public class GetCustomersByNameHandler : IRequestHandler<GetCustomersByNameQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public GetCustomersByNameHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersByNameQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repo.GetCustomersByName(request.searchParam);
            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
