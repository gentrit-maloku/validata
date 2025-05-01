using MediatR;
using Validata.Application.Dtos;

namespace Validata.Application.Queries.Orders
{
    public class ListOrdersByCustomerQuery : IRequest<List<OrderDto>>
    {
        public Guid CustomerId { get; set; }

        public string SortOrder { get; set; }
    }
}
