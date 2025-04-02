using ErpSystemManagement.Application.Features.Products.Commands.CreateProduct;
using FluentValidation;

namespace ErpSystemManagement.Application.Features.Products.Validators.CreateProductValidator;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
    }
}