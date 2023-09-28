using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repo;

        public ProductsController(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var spec = new ProductWidthTypeAndBrandSpecification();
            var product = await _repo.ListAsync(spec);
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
        /*[HttpGet("brand")]

       public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
       {
           var brands = await _repo.GetProductBrandAsync();
           return Ok(brands);
       }

       [HttpGet("type")]
       public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
       {
           var types = await _repo.GetProductTypeAsync();
           return Ok(types);
       }*/
    }
}