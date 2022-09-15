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
        return "Get!";
    }

    [HttpPost]
    [Route("")]
    public string Post ()
    {
        return "Post";
    }

    [HttpPut]
    [Route("")]
    public string Put ()
    {
        return "Put";
    }

    [HttpDelete]
    [Route("")]
    public string Delete ()
    {
        return "Delete";
    }
}