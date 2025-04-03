using ErpSystemManagement.Application.Features.Recipes.Queries.GetRecipeByIdWithDetails;
using ErpSystemManagement.Application.Features.Recipes.Commands.CreateRecipe;
using ErpSystemManagement.Application.Features.Recipes.Commands.DeleteRecipe;
using ErpSystemManagement.Application.Features.Recipes.Queries.GetAllRecipes;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class RecipesController : ApiController
{
    public RecipesController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllRecipesQuery getAllRecipesQuery, CancellationToken cancellationToken) =>
        await HandleRequest(getAllRecipesQuery, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Create(CreateRecipeCommand createRecipeCommand, CancellationToken cancellationToken) =>
        await HandleRequest(createRecipeCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteRecipeCommand deleteRecipeCommand, CancellationToken cancellationToken) =>
        await HandleRequest(deleteRecipeCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> GetByIdWithDetails(GetRecipeByIdWithDetailsQuery getRecipeByIdWithDetailsQuery, CancellationToken cancellationToken) =>
        await HandleRequest(getRecipeByIdWithDetailsQuery, cancellationToken);
}