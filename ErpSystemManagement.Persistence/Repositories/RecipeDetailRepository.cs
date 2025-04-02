using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class RecipeDetailRepository : Repository<RecipeDetail, AppDbContext>, IRecipeDetailRepository
{
    public RecipeDetailRepository(AppDbContext context) : base(context) { }
}