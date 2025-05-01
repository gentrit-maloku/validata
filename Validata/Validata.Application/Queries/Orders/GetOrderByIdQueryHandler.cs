using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Validata.Application.Dtos;
using Validata.Application.Interfaces;
using Validata.Application.Queries.Orders;

namespace Validata.Application.Handlers.Orders
{
    public class GetOrderByIdQueryHandler(
        IUnitOfWork unitOfWork,
        ILogger<GetOrderByIdQueryHandler> logger,
        IMapper mapper)
        : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.Orders.GetByIdAsync(request.OrderId);

            if (order == null)
            {
                logger.LogWarning("Order not found: {OrderId}", request.OrderId);

                return null!;
            }

            return mapper.Map<OrderDto>(order);
        }
    }
}
