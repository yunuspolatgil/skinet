using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProduct()
        {
            var spec = new ProductWidthTypeAndBrandSpecification();
            var product = await _repo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(product));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductWidthTypeAndBrandSpecification(id);
            var product = await _repo.GetEntityWidthSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            
            return _mapper.Map<Product, ProductToReturnDto>(product);
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