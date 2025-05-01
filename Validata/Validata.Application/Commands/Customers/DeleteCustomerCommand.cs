using MediatR;

namespace Validata.Application.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }

        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
