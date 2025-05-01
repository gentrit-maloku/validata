using FluentValidation;
using Validata.Application.Commands.Customers;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");
    }
}
