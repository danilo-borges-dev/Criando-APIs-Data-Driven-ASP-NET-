using Microsoft.AspNetCore.Mvc;

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
    public string Post ()
    {
        return "POST";
    }

    [HttpPut]
    [Route("")]
    public string Put ()
    {
        return "PUT";
    }

    [HttpDelete]
    [Route("")]
    public string Delete ()
    {
        return "DELETE";
    }
}