using ErpSystemManagement.Application.Features.RecipeDetails.Commands.CreateRecipeDetail;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.DeleteRecipeDetail;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.UpdateRecipeDetail;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class RecipeDetailsController : ApiController
{
    public RecipeDetailsController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> Create(CreateRecipeDetailCommand createRecipeDetailCommand, CancellationToken cancellationToken) =>
        await HandleRequest(createRecipeDetailCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Update(UpdateRecipeDetailCommand updateRecipeDetailCommand, CancellationToken cancellationToken) =>
        await HandleRequest(updateRecipeDetailCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteRecipeDetailCommand deleteRecipeDetailCommand, CancellationToken cancellationToken) =>
        await HandleRequest(deleteRecipeDetailCommand, cancellationToken);
}