using MediatR;
using Validata.Application.Dtos;

namespace Validata.Application.Queries.Customers
{
    public class GetCustomerByIdQuery(Guid customerId) : IRequest<CustomerDto>
    {
        public Guid CustomerId { get; } = customerId;
    }
}
