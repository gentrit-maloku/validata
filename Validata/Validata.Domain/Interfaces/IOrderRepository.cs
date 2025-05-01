using Validata.Domain.Entities;

namespace Validata.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetByCustomerIdAsync(Guid customerId, bool sortByOrderDate);

        Task<Order?> GetByIdAsync(Guid id);

        Task AddAsync(Order entity);

        void Remove(Order entity);
    }
}
