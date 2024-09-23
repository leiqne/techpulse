using API.Entities.Orders;
using API.Entities.Orders.Interfaces;

namespace API.Services.Orders.Interfaces;

public interface IOrderService
{
    Task<Order?> Handle(OrderResource orderResource);
}