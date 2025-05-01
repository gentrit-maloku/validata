using MediatR;
using Validata.Application.Interfaces;

namespace Validata.Application.Commands.Customers
{
    public class UpdateCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCustomerCommand, bool>
    {
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId);

            if (customer == null) return false;

            customer.Update(request.FirstName, request.LastName, request.Address, request.PostalCode);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
