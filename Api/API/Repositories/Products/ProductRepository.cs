using API.Configuration;
using API.Entities.Products;
using API.Entities.Providers;
using API.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Products;

public class ProductRepository : IProductRepository
{
    protected readonly AppDbContext Context;

    public ProductRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task Create(Product product)
    {
        await Context.Set<Product>().AddAsync(product);
        await Context.SaveChangesAsync();
    }

    public async Task<Product?> SearchById(int id)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(product => product.Id.Equals(id));
    }
}