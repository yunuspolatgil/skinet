using API.Dtos;
using API.Errors;
using API.Helpers;
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
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductBrand> _typeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repo,IMapper mapper, IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductBrand> typeRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProduct(
            [FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductWidthTypeAndBrandSpecification(productParams);

            var countSpec = new ProductWithFilterForCountSpecification(productParams);
            
            var totalItems = await _repo.CountAsync(countSpec);
            
            var product = await _repo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(product);
            
            return Ok(
                new Pagination<ProductToReturnDto>(productParams.PageIndex,productParams.PageSize,totalItems,data));
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
        [HttpGet("brands")]

       public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
       {
           return Ok(await _brandRepo.ListAllAsync());
       }

       [HttpGet("types")]
       public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
       {
           return Ok(await _typeRepo.ListAllAsync());
       }
    }
}