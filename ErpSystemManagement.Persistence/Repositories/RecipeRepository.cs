using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class RecipeRepository : Repository<Recipe, AppDbContext>, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context) { }
}