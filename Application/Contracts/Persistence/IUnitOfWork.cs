using System;
using System.Threading.Tasks;

namespace CustomerCruncher.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
    }
}