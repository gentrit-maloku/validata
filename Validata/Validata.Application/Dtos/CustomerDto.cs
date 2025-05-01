namespace Validata.Application.Dtos
{
    public sealed record CustomerDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }
    }
}
