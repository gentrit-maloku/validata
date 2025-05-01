using AutoMapper;
using MediatR;
using Validata.Application.Dtos;
using Validata.Application.Interfaces;

namespace Validata.Application.Queries.Customers
{
    public class ListCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ListCustomersQuery, List<CustomerDto>>
    {
        public async Task<List<CustomerDto>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await unitOfWork.Customers.GetAllAsync();

            return mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
