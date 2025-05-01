namespace Validata.Application.Dtos
{
    public sealed record OrderDto
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
