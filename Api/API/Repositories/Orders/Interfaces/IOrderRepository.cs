using API.Entities.Orders;

namespace API.Repositories.Orders.Interfaces;

public interface IOrderRepository
{
    Task Create(Order order);
}