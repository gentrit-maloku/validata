using Validata.Application.Interfaces.Common;
using Validata.Domain.Entities;

namespace Validata.Application.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetByCustomerIdAsync(Guid customerId);
    }
}
