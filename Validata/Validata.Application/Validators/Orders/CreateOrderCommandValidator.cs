using FluentValidation;
using Validata.Application.Commands.Orders;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");

        RuleFor(x => x.OrderDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Order date cannot be in the past.");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Order must contain at least one item.")
            .ForEach(item =>
            {
                item.SetValidator(new OrderItemDtoValidator());
            });
    }
}
