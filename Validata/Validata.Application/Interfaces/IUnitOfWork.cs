using Validata.Application.Interfaces.Common;
using Validata.Domain.Entities;

namespace Validata.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }

        IOrderRepository Orders { get; }

        IRepository<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
