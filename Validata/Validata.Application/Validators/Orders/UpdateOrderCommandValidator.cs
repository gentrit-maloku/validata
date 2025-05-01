using FluentValidation;
using Validata.Application.Commands.Orders;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("Order ID is required.");

        RuleFor(x => x.OrderDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Order date cannot be in the past.");

        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("Updated order must contain at least one item.")
            .ForEach(item =>
            {
                item.SetValidator(new OrderItemDtoValidator());
            });
    }
}
