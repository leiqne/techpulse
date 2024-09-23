using System.Net.Mime;
using API.Entities.Reviews.Interfaces;
using API.Services.Reviews.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/review")]
[Produces(MediaTypeNames.Application.Json)]
public class ReviewController(IReviewService reviewService) : ControllerBase
{
    [HttpPost("new-review")]
    public async Task<IActionResult> NewReview(ReviewResource reviewResource)
    {
        var review = await reviewService.Handle(reviewResource);
        if (review is null) return BadRequest();
        return Ok();
    }
}