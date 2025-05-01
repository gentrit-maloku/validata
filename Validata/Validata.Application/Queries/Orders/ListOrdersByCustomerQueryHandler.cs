using AutoMapper;
using MediatR;
using Validata.Application.Dtos;
using Validata.Application.Interfaces;
using Validata.Application.Queries.Orders;

namespace Validata.Application.Handlers.Orders
{
    public class ListOrdersByCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<ListOrdersByCustomerQuery, List<OrderDto>>
    {
        public async Task<List<OrderDto>> Handle(ListOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.Orders.GetByCustomerIdAsync(request.CustomerId, sortByOrderDate: request.SortOrder == "desc");

            return mapper.Map<List<OrderDto>>(orders);
        }
    }
}
