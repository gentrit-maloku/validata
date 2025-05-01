namespace Validata.Application.Dtos
{
    public sealed record OrderItemDto
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
