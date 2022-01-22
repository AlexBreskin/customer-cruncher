using AutoMapper;
using CustomerCruncher.Application.Contracts.Persistence;
using CustomerCruncher.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using System;

namespace CustomerCruncher.Infrastracture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ICustomerRepository _customerRepository;


        public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public ICustomerRepository CustomerRepository =>
            _customerRepository ??= new CustomerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}