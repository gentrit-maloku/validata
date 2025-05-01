using NUnit.Framework.Legacy;
using Validata.Application.Commands.Orders;
using Validata.Application.Dtos;
using Validata.Domain.Entities;

namespace Validata.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void CreateOrder_ShouldCalculateTotalPrice()
        {
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                Items = new List<OrderItemDto>
            {
                new OrderItemDto { ProductName = "Laptop", ProductPrice = 20, Quantity = 10 },
                new OrderItemDto { ProductName = "Mouse", ProductPrice = 50, Quantity = 5 }
            }
            };

            var items = command.Items.Select(dto => new OrderItem(
                new Product(dto.ProductName, dto.ProductPrice),
                dto.Quantity
            )).ToList();

            var order = new Order(command.OrderDate, items);

            ClassicAssert.AreEqual(450, order.TotalPrice);
        }

        [Test]
        public void UpdateOrder_ShouldUpdateItems()
        {
            var originalItems = new List<OrderItem> { new OrderItem(new Product("Laptop", 100), 1) };
            var order = new Order(DateTime.Now, originalItems);

            var command = new UpdateOrderCommand
            {
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.Now.AddDays(1),
                Items = new List<OrderItemDto>
            {
                new OrderItemDto { ProductName = "Tablet", ProductPrice = 50, Quantity = 2 }
            }
            };

            var updatedItems = command.Items.Select(dto => new OrderItem(
                new Product(dto.ProductName, dto.ProductPrice),
                dto.Quantity
            )).ToList();

            order.Update(command.OrderDate, updatedItems);

            ClassicAssert.AreEqual(100, order.TotalPrice);
            ClassicAssert.AreEqual("Tablet", order.Items.First().Product.Name);
        }

        [Test]
        public void CreateOrder_ShouldSetCorrectTotalPrice()
        {
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                Items =
            [
                new OrderItemDto { ProductName = "Laptop", ProductPrice = 20, Quantity = 2 },
                new OrderItemDto { ProductName = "Mouse", ProductPrice = 10, Quantity = 5 }
            ]
            };

            var customer = new Customer("John", "Doe", "123 St", "12345");
            var items = command.Items.Select(dto => new OrderItem(
                new Product(dto.ProductName, dto.ProductPrice),
                dto.Quantity
            )).ToList();

            var order = new Order(command.OrderDate, items);

            ClassicAssert.AreEqual(90, order.TotalPrice);
        }
    }
}
