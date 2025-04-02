using ErpSystemManagement.Application.Features.Products.Commands.CreateProduct;
using ErpSystemManagement.Application.Features.Products.Commands.DeleteProduct;
using ErpSystemManagement.Application.Features.Products.Commands.UpdateProduct;
using ErpSystemManagement.Application.Features.Products.Queries.GetAllProducts;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductsQuery getAllProductsQuery, CancellationToken cancellationToken)
        => await HandleRequest(getAllProductsQuery, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        => await HandleRequest(createProductCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        => await HandleRequest(updateProductCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteProductCommand deleteProductCommand, CancellationToken cancellationToken)
        => await HandleRequest(deleteProductCommand, cancellationToken);
}