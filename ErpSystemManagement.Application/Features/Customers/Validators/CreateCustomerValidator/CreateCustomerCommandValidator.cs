using ErpSystemManagement.Application.Features.Customers.Commands.CreateCustomer;
using FluentValidation;

namespace ErpSystemManagement.Application.Features.Customers.Validators.CreateCustomerValidator;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.TaxNumber).MinimumLength(10).MaximumLength(11);
        RuleFor(c => c.Name).MinimumLength(3);
    }
}