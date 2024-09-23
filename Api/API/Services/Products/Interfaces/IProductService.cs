using API.Entities.Products;
using API.Entities.Products.Interfaces;

namespace API.Services.Products.Interfaces;

public interface IProductService
{
    Task<Product?> Handle(ProductResource productResource);
}