using API_rest.API.Models;
using API_rest.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_rest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        [FormatFilter]
        //Cas de l'action Get() sans arguments, on verifie le .json directement pour la page recipe
        [HttpGet("~/api/{page=recipe}.{format?}")]
        public ActionResult<Result> Get()
        {
            RecipeRepository recipeRepository = new RecipeRepository();
            
            Result result = new Result(200, "OK", recipeRepository.Read());

            return result;
        }
    }
}