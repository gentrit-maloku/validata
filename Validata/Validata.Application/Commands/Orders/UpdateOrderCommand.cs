using MediatR;
using Validata.Application.Dtos;

namespace Validata.Application.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();

        public DateTime OrderDate { get; set; }
    }
}
