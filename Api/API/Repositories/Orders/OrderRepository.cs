using API.Configuration;
using API.Entities.Orders;
using API.Repositories.Orders.Interfaces;

namespace API.Repositories.Orders;

public class OrderRepository : IOrderRepository
{
    protected readonly AppDbContext Context;

    public OrderRepository(AppDbContext context)
    {
        Context = context;
    }
    
    public async Task Create(Order order)
    {
        await Context.Set<Order>().AddAsync(order);
        await Context.SaveChangesAsync();
    }
}