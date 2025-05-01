using MediatR;
using Validata.Application.Interfaces;
using Validata.Domain.Entities;

namespace Validata.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.FirstName, request.LastName, request.Address, request.PostalCode);

            await unitOfWork.Customers.AddAsync(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
