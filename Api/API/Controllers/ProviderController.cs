using System.Net.Mime;
using API.Entities.Providers;
using API.Entities.Providers.Interfaces;
using API.Services.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/provider")]
[Produces(MediaTypeNames.Application.Json)]
public class ProviderController(IProviderService providerService) : ControllerBase
{
    [HttpPost("new-provider")]
    public async Task<IActionResult> NewProvider(ProviderResource providerResource)
    {
        var provider = await providerService.Handle(providerResource);
        if (provider is null) return BadRequest();
        return Ok();
    }
}