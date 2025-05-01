using Validata.Application.Interfaces.Common;
using Validata.Application.Interfaces;
using Validata.Domain.Entities;

namespace Validata.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ValidataDbContext _context;

        public UnitOfWork(ValidataDbContext context)
        {
            _context = context;
            Customers = new Repository<Customer>(_context);
            Orders = new OrderRepository(_context);
            Products = new Repository<Product>(_context);
        }

        public IRepository<Customer> Customers { get; }

        public IOrderRepository Orders { get; }

        public IRepository<Product> Products { get; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
