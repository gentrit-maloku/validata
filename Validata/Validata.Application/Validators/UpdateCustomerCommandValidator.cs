using FluentValidation;
using Validata.Application.Commands.Customers;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(100);

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .MaximumLength(10);
    }
}
