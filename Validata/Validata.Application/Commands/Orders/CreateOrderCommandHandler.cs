using MediatR;
using Validata.Application.Interfaces;
using Validata.Domain.Entities;

namespace Validata.Application.Commands.Orders
{
    public class CreateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId);

            if (customer == null)
                throw new ArgumentException("Customer not found");

            var orderItems = new List<OrderItem>();

            foreach (var item in request.Items)
            {
                var product = await unitOfWork.Products.GetByIdAsync(item.ProductId);

                if (product == null)
                    throw new ArgumentException($"Product with ID {item.ProductId} not found");

                if (item.ProductPrice != product.Price)
                    throw new ArgumentException($"Price mismatch for product {product.Name}");

                orderItems.Add(new OrderItem(product, item.Quantity));
            }

            var order = new Order(request.OrderDate, orderItems);

            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }

}
