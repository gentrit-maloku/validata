using MediatR;
using Validata.Application.Dtos;

namespace Validata.Application.Queries.Customers
{
    public class ListCustomersQuery : IRequest<List<CustomerDto>> { }
}
