namespace Validata.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }

        public Guid OrderId { get; private set; }

        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal TotalPrice => Quantity * Product.Price;

        public Product Product { get; private set; }

        private OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than 0.");

            Id = Guid.NewGuid();
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
        }
    }
}
