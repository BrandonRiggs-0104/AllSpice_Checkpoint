using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AllSpice_Checkpoint.Controllers;
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
         private readonly Auth0Provider _auth;


        public RecipesController(RecipesService recipesService, Auth0Provider auth)
        {
           
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Recipe>>
        CreateRecpie([FromBody] RecipesController recipeData)
        {
            try
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
        Recipe recipe = _recipesService.CreateRecpie(recipeData);
        recipe.Creator = userInfo;
        return Ok(recipe)
            }
            catch (Exception e)
            {
            return BadRequest(e.Message)
            }
        }

    }
