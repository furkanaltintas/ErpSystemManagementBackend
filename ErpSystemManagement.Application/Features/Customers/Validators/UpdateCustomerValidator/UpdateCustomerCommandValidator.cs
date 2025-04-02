using ErpSystemManagement.Application.Features.Customers.Commands.UpdateCustomer;
using FluentValidation;

namespace ErpSystemManagement.Application.Features.Customers.Validators.UpdateCustomerValidator;

class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.TaxNumber).MinimumLength(10).MaximumLength(11);
        RuleFor(c => c.Name).MinimumLength(3);
    }
}