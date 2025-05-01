using MediatR;
using Validata.Application.Dtos;

namespace Validata.Application.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid OrderId { get; set; }
    }
}
