using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProduct()
        {
            return "Get Product All";
        }
        [HttpGet("{id}")]
        public string GetProductById(int id)
        {
            return @"Get Product By ID";
        }
    }
}