using API.Entities.Products;

namespace API.Repositories.Products.Interfaces;

public interface IProductRepository
{
    Task Create(Product product);
    Task<Product?> SearchById(int id);
}