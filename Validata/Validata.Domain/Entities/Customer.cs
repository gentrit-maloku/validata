namespace Validata.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Address { get; private set; }

        public string PostalCode { get; private set; }


        private readonly List<Order> _orders = new();

        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        private Customer() { }

        public Customer(string firstName, string lastName, string address, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name is required.");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address is required.");
            if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("Postal code is required.");

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _orders.Add(order);
        }

        public void Update(string firstName, string lastName, string address, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }
    }
}
