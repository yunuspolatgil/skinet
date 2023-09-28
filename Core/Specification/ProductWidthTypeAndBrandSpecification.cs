using Core.Entities;

namespace Core.Specification;

public class ProductWidthTypeAndBrandSpecification : BaseSpecification<Product>
{
    public ProductWidthTypeAndBrandSpecification()
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }
}