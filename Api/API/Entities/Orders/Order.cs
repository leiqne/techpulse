using System.Runtime.InteropServices.JavaScript;
using API.Entities.Orders.Interfaces;
using API.Entities.Products;
using API.Entities.Users;

namespace API.Entities.Orders;

public class Order
{
    public Order()
    {
        UId = 0;
        ProdId = 0;
        Amount = new PayAmount();
        Date = new OrderDate();
        State = new OrderState();
        Method = new ShippingMethod();
    }

    public Order(OrderResource orderResource)
    {
        UId = orderResource.UId;
        ProdId = orderResource.ProdId;
        Amount = new PayAmount(orderResource.PayAmount);
        Date = new OrderDate(orderResource.OrderDate);
        State = new OrderState(orderResource.OrderState);
        Method = new ShippingMethod(orderResource.ShippingMethod);
    }

    public int Id { get; }
    public int UId { get; set; }
    public int ProdId { get; set; }
    public PayAmount Amount { get; set; }
    public OrderDate Date { get; set; }
    public OrderState State { get; set; }
    public ShippingMethod Method { get; set; }
    
    public User User { get; set; }
    public Product Product { get; set; }
}