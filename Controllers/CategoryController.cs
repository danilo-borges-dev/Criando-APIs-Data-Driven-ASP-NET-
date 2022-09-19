using Microsoft.AspNetCore.Mvc;
using Shop.Models;

// Endpoint == URL
// http://localhost/5000
// https://localhost/5001 - Produção usar sempre o https
// https://meuapp.azurewebsites.net/ 
// (Quando for para o meu Servidor terei o meu domínio como base meuapp.nomedodominio.com)

// https://localhost/5001/categories/
[Route("categories")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Get ()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById (int id)
    {
        return new Category();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post ([FromBody]Category model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(model);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Put (int id, [FromBody]Category model)
    {
        // Verifica se o ID informado é o mesmo do modelo
        if (model.Id == id) 
        {
            return NotFound(new { message = "Categoria não econtrada "});
        }

        // Verifica se os dados são válidos
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Delete ()
    {
        return Ok();
    }
}