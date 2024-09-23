using API.Entities.Orders;
using API.Entities.Orders.Interfaces;
using API.Repositories.Orders.Interfaces;
using API.Repositories.Products.Interfaces;
using API.Repositories.Users.Interfaces;
using API.Services.Orders.Interfaces;

namespace API.Services.Orders;

public class OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository) : IOrderService
{
    public async Task<Order?> Handle(OrderResource orderResource)
    {
        var user = await userRepository.SearchById(orderResource.UId);
        var product = await productRepository.SearchById(orderResource.ProdId);

        if (user == null)
        {
            throw new Exception("Invalid User Id");
        }
        if (product == null)
        {
            throw new Exception("Invalid Product Id");
        }
        if (user == null & product == null)
        {
            throw new Exception("Invalid User Id and Product Id");
        }

        var order = new Order(orderResource);
        await orderRepository.Create(order);
        return order;
    }
}