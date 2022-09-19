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
    public string Get ()
    {
        return "GET!";
    }

    [HttpGet]
    [Route("{id:int}")]
    public string GetById (int id)
    {
        return $"GET ID! {id}";
    }

    [HttpPost]
    [Route("")]
    public Category Post ([FromBody]Category model)
    {
        return model;
    }

    [HttpPut]
    [Route("{id:int}")]
    public Category Put (int id, [FromBody]Category model)
    {
        if (model.Id == id) 
        {
            return model;
        }
        return null;
    }

    [HttpDelete]
    [Route("{id:int}")]
    public string Delete ()
    {
        return "DELETE";
    }
}