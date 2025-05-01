using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Validata.Application.Commands.CreateCustomer;
using Validata.Application.Commands.Customers;
using Validata.Application.Dtos;
using Validata.Application.Queries.Customers;

namespace Validata.Api.Controllers
{
    /// <summary>
    /// CustomersController
    /// </summary>
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="command">The command containing the customer data</param>
        /// <returns>Customer ID</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>A list of all customers</returns>
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            var customers = await mediator.Send(new ListCustomersQuery());
            return Ok(customers);
        }

        /// <summary>
        /// Get a customer by ID
        /// </summary>
        /// <param name="id">The customer ID</param>
        /// <returns>The customer details</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            var customer = await mediator.Send(new GetCustomerByIdQuery(id));

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        /// <summary>
        /// Update customer details by ID
        /// </summary>
        /// <param name="id">The customer ID</param>
        /// <param name="command">The command containing the updated customer data</param>
        /// <returns>No content status</returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            command.CustomerId = id;
            await mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete a customer by ID
        /// </summary>
        /// <param name="id">The customer ID</param>
        /// <returns>No content status</returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }
    }
}
