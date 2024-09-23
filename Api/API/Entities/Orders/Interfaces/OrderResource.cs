namespace API.Entities.Orders.Interfaces;

public record OrderResource(double PayAmount, DateTime OrderDate, string OrderState, string ShippingMethod, int UId, int ProdId);