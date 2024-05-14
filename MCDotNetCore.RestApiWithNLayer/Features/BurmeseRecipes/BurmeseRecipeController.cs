using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MCDotNetCore.RestApiWithNLayer.Features.BurmeseRecipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseRecipeController : ControllerBase
    {
        private async Task<List<BurmeseRecipe>> GetDataAsync()
        {
            string jsonstr =await System.IO.File.ReadAllTextAsync("BurmeseRecipes.json");
            var model = JsonConvert.DeserializeObject<List<BurmeseRecipe>>(jsonstr);
            return model;
        }

        [HttpGet("recipes")]
        public async Task<IActionResult> GetRecipeList()
        {
            var recipeList = await GetDataAsync();
            return Ok(recipeList);
        }

        [HttpGet("recipes/{guid}")]
        public async Task<IActionResult> GetRecipe(string guid)
        {
            var recipeList = await GetDataAsync();
            var recipe = recipeList.FirstOrDefault(x => x.Guid == guid);
            return Ok(recipe);
        }
    }

    public class BurmeseRecipe
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string CookingInstructions { get; set; }
        public string UserType { get; set; }
    }

}
