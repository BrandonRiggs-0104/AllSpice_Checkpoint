using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice_Checkpoint.Repositories;
    public class RecipesRepository
{
    private readonly IDbConnection _db;

public RecipesRepository(IDbConnection db)
    {
    _db = db;
    }


    internal Recipe CreateRecipe(Recipe recipeData)
    {
     string sql = @"
    INSERT INTO recipes
    (title, instructions, img, category, creatorId)
    VALUES
    (@title, @instructions, @img, @category, @creatorId);

    SELECT
    rec.*,
    creator.*
    FROM recipes rec
    JOIN accounts creator ON rec.creatorId = creator.id
    WHERE rec.id = LAST_INSERT_ID();
    ";
    Recipe newRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }, recipeData).FirstOrDefault();
    return newRecipe;
    }
}