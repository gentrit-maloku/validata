using Microsoft.EntityFrameworkCore;
using Validata.Application.Interfaces;
using Validata.Domain.Entities;

namespace Validata.Infrastructure.Repository
{
    public class OrderRepository(ValidataDbContext context) : Repository<Order>(context), IOrderRepository
    {
        public async Task<List<Order>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
