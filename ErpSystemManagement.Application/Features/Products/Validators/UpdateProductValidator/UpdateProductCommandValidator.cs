using ErpSystemManagement.Application.Features.Products.Commands.UpdateProduct;
using FluentValidation;

namespace ErpSystemManagement.Application.Features.Products.Validators.UpdateProductValidator;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        
    }
}