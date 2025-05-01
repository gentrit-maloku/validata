using FluentValidation;
using Validata.Application.Dtos;

public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.");

        RuleFor(x => x.ProductPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Unit price must be non-negative.");
    }
}
