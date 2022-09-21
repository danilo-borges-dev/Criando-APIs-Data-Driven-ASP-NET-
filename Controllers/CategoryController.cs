using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Data;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<List<Category>>> Get(
        [FromServices] DataContext context
    )
    {
        var categories = await context.Categories.AsNoTracking().ToListAsync();
        return Ok(categories);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById(
        int id,
        [FromServices] DataContext context
    )
    {
        var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return new Category();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post(
        [FromBody] Category model,
        [FromServices] DataContext context
        )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível criar a categoria." });
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Put(
        int id,
        [FromBody] Category model,
        [FromServices] DataContext context
        )
    {
        // Verifica se o ID informado é o mesmo do modelo
        if (model.Id == id)
        {
            return NotFound(new { message = "Categoria não econtrada " });
        }

        // Verifica se os dados são válidos
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Este Registro já foi atualizado. " });
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível atualizar a categoria. " });
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Delete(
        int id,
        [FromServices] DataContext context
    )
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if(category == null)
        {
            return NotFound(new { message = "Categoria não econtrada. "});
        }
        
        try
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok( new { message = "Categoria removida com sucesso. " } );
        }
        catch (Exception) 
        {
            return BadRequest( new { message = "Não foi possível remover a categoria. "});
        }
    }
}