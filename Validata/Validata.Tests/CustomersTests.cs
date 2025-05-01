using NUnit.Framework.Legacy;
using Validata.Domain.Entities;

namespace ValidataApi.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void CalculateOrderTotal_ShouldReturnCorrectSum()
        {
            // Arrange
            var product = new Product("SampleProduct", 20);
            var orderItems = new List<OrderItem> { new OrderItem(product, 3) };
            var order = new Order(DateTime.Now, orderItems);

            // Act & Assert
            ClassicAssert.AreEqual(60, order.TotalPrice);
        }

        [Test]
        public void ChangeCustomerDetails_ShouldUpdateAttributes()
        {
            // Arrange
            var customer = new Customer("Alice", "Green", "789 Elm St", "54321");

            // Act
            customer.Update("Bob", "Blue", "321 Oak St", "12345");

            // Assert
            ClassicAssert.AreEqual("Bob", customer.FirstName);
            ClassicAssert.AreEqual("Blue", customer.LastName);
            ClassicAssert.AreEqual("321 Oak St", customer.Address);
            ClassicAssert.AreEqual("12345", customer.PostalCode);
        }

        [Test]
        public void RemoveOrder_ShouldEmptyCustomerOrders()
        {
            // Arrange
            var customer = new Customer("Charlie", "Brown", "101 Pine St", "11223");
            var order = new Order(DateTime.Now, new List<OrderItem> { new OrderItem(new Product("Product A", 30), 1) });

            // Act
            customer.AddOrder(order);
            customer.RemoveOrder(order.Id);

            // Assert
            ClassicAssert.IsEmpty(customer.Orders);
        }
    }
}
