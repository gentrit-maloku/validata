using MediatR;

namespace Validata.Application.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
    }
}
