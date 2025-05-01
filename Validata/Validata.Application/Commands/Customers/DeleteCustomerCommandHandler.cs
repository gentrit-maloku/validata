using MediatR;
using Validata.Application.Interfaces;

namespace Validata.Application.Commands.Customers
{
    public class DeleteCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerCommand, bool>
    {
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer == null) return false;

            unitOfWork.Customers.Remove(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
