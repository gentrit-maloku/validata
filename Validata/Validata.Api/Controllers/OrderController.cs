using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Validata.Application.Commands.Orders;
using Validata.Application.Queries.Orders;

namespace Validata.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Creates a new order.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderId = await mediator.Send(command);

            return CreatedAtAction(
                nameof(GetOrder),
                new { version = HttpContext.GetRequestedApiVersion()?.ToString(), id = orderId },
                orderId);
        }

        /// <summary>
        /// Gets a single order by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var query = new GetOrderByIdQuery { OrderId = id };
            var order = await mediator.Send(query);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Gets all orders for a customer.
        /// </summary>
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId, [FromQuery] string sortOrder = "asc")
        {
            bool isSortDescending = sortOrder.ToLower() == "desc";

            var query = new ListOrdersByCustomerQuery
            {
                CustomerId = customerId,
                SortOrder = sortOrder
            };

            var orders = await mediator.Send(query);

            return Ok(orders);
        }

        /// <summary>
        /// Updates an order.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderCommand command)
        {
            if (!ModelState.IsValid || id != command.OrderId)
                return BadRequest(ModelState);

            var result = await mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Deletes an order.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand { OrderId = id };
            var result = await mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}
