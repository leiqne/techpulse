using System.Net.Mime;
using API.Entities.Orders.Interfaces;
using API.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/order")]
[Produces(MediaTypeNames.Application.Json)]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost("new-order")]
    public async Task<IActionResult> NewOrder(OrderResource orderResource)
    {
        var order = await orderService.Handle(orderResource);
        if (order is null) return BadRequest();
        return Ok();
    }
}