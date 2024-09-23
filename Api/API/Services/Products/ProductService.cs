using API.Entities.Products;
using API.Entities.Products.Interfaces;
using API.Repositories.Products.Interfaces;
using API.Repositories.Providers.Interfaces;
using API.Services.Products.Interfaces;

namespace API.Services.Products;

public class ProductService(IProductRepository productRepository, IProviderRepository providerRepository) : IProductService
{
    public async Task<Product?> Handle(ProductResource productResource)
    {
        var provider = await providerRepository.SearchById(productResource.PId);

        if (provider == null)
        {
            throw new Exception("Invalid Provider Id");
        }
        
        var product = new Product(productResource);
        await productRepository.Create(product);
        return product;
    }
}