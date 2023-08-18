using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice_Checkpoint.Services;
    public class RecipeService
{
    private readonly RecipesRepository _repo;
    
    public RecipeService(RecipesRepository repo)
    {
        _repo = repo;
    }
    

    internal RecipeService CreateRecipe(RecipeService recipeData)
    {
        RecipeService recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }
}