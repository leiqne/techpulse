using API.Entities.Orders;
using API.Entities.Products.Interfaces;
using API.Entities.Providers;
using API.Entities.Reviews;

namespace API.Entities.Products;

public class Product
{
    public Product()
    {
        Name = new ProductName();
        PId = 0;
    }

    public Product(ProductResource productResource)
    {
        Name = new ProductName(productResource.Name);
        PId = productResource.PId;
    }

    public int Id { get; }
    public ProductName Name { get; set; }
    public int PId { get; set; }
    public Provider Provider { get; set; }
    public ICollection<Review> Reviews { get; }
    public ICollection<Order> Orders { get; }
}