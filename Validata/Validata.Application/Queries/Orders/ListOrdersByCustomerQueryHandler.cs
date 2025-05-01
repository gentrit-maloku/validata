using MediatR;
using Validata.Application.Dtos;
using Validata.Application.Interfaces;
using Validata.Application.Queries.Orders;

namespace Validata.Application.Handlers.Orders
{
    public class ListOrdersByCustomerQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<ListOrdersByCustomerQuery, List<OrderDto>>
    {
        public async Task<List<OrderDto>> Handle(ListOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.Orders.GetByCustomerIdAsync(request.CustomerId);

            return orders.Select(order => new OrderDto
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Items = order.Items.Select(i => new OrderItemDto
                {
                    ProductId = i.Product.Id,
                    ProductPrice = i.Product.Price,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }
    }
}
