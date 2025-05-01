using AutoMapper;
using MediatR;
using Validata.Application.Dtos;
using Validata.Application.Interfaces;

namespace Validata.Application.Queries.Customers
{
    public class GetCustomerByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId);

            return mapper.Map<CustomerDto>(customer);
        }
    }
}
