using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification;

public class ProductWidthTypeAndBrandSpecification : BaseSpecification<Product>
{
    public ProductWidthTypeAndBrandSpecification()
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }

    public ProductWidthTypeAndBrandSpecification(int id):base(x => x.Id == id)
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }
}