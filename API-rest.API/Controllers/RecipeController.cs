using API_rest.API.Models;
using API_rest.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
         // GET api/values
        [HttpGet]
        public ActionResult<Result> Get()
        {
            RecipeRepository recipeRepository = new RecipeRepository();
            
            Result result = new Result(200, "OK", recipeRepository.Read());

            return result;
        }
    }
}