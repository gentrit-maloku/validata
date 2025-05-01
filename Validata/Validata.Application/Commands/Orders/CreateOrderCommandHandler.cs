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

            var orderItems = request.Items.Select(dto => new OrderItem(new Product(dto.ProductName, dto.ProductPrice), dto.Quantity)).ToList();

            var order = new Order(request.OrderDate, orderItems);
            customer.AddOrder(order);

            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }

}
