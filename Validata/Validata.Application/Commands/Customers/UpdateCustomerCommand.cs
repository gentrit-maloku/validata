using MediatR;
using System.Text.Json.Serialization;

namespace Validata.Application.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        [JsonIgnore]
        public Guid CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }
    }
}
