using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var product = await _repo.GetProductAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
        [HttpGet("brand")]
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
        }
    }
}