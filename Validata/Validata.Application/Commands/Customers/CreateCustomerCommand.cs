using MediatR;

namespace Validata.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Address { get; init; }

        public string PostalCode { get; init; }
    }
}
