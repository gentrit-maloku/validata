using MediatR;
using Validata.Application.Dtos;

namespace Validata.Application.Commands.Orders
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();

        public DateTime OrderDate { get; set; }
    }
}
