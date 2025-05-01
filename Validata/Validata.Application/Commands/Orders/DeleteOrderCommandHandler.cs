using MediatR;
using Validata.Application.Interfaces;

namespace Validata.Application.Commands.Orders
{
    public class DeleteOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderCommand, bool>
    {
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.Orders.GetByIdAsync(request.OrderId);

            if (order == null)
                return false;

            unitOfWork.Orders.Remove(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
