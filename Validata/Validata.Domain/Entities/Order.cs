namespace Validata.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

        private readonly List<OrderItem> _items = new();

        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        private Order() { }

        public Order(DateTime orderDate, List<OrderItem> items)
        {
            if (items == null || !items.Any()) throw new ArgumentException("Order must have at least one item.");
            OrderDate = orderDate;
            Id = Guid.NewGuid();
            _items = items;
        }

        public void AddItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void Update(DateTime orderDate, List<OrderItem> newItems)
        {
            if (newItems == null || !newItems.Any())
                throw new ArgumentException("Order must have at least one item.");

            OrderDate = orderDate;

            _items.Clear();
            _items.AddRange(newItems);
        }
    }
}
