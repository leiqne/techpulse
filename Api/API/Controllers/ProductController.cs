using System.Net.Mime;
using API.Entities.Products.Interfaces;
using API.Entities.Providers.Interfaces;
using API.Services.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/product")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost("new-product")]
    public async Task<IActionResult> NewProduct(ProductResource productResource)
    {
        var product = await productService.Handle(productResource);
        if (product is null) return BadRequest();
        return Ok();
    }
}