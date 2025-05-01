using MediatR;
using Microsoft.Extensions.Logging;
using Validata.Application.Interfaces;
using Validata.Domain.Entities;

namespace Validata.Application.Commands.Orders
{
    public class UpdateOrderCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateOrderCommandHandler> logger) : IRequestHandler<UpdateOrderCommand, bool>
    {
        public async Task<bool> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating order {OrderId}", command.OrderId);

            var order = await unitOfWork.Orders.GetByIdAsync(command.OrderId);

            if (order == null)
            {
                logger.LogWarning("Order not found: {OrderId}", command.OrderId);

                return false;
            }

            var items = new List<OrderItem>();

            foreach (var dto in command.Items)
            {
                var product = await unitOfWork.Products.GetByIdAsync(dto.ProductId);

                if (product == null)
                {
                    logger.LogWarning("Product not found: {ProductId}", dto.ProductId);
                    continue;
                }

                items.Add(new OrderItem(product, dto.Quantity));
            }

            order.Update(command.OrderDate, items);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Order {OrderId} successfully updated", command.OrderId);

            return true;
        }
    }
}
