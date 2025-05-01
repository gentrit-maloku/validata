using Microsoft.EntityFrameworkCore;
using Validata.Application.Interfaces;
using Validata.Domain.Entities;

namespace Validata.Infrastructure.Repository
{
    public class OrderRepository(ValidataDbContext context) : Repository<Order>(context), IOrderRepository
    {
        public async Task<List<Order>> GetByCustomerIdAsync(Guid customerId, bool sortByOrderDate)
        {
            var query = _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.CustomerId == customerId);

            if (sortByOrderDate)
                query = query.OrderByDescending(o => o.OrderDate);

            else
                query = query.OrderBy(o => o.OrderDate);

            return await query.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
