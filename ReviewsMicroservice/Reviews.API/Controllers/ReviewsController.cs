using Microsoft.AspNetCore.Mvc;
using Reviews.ApplicationCore.Contracts.Services;

namespace Reviews.API.Controllers;
using Reviews.ApplicationCore.Entities;

[Route("reviews")]
[ApiController]
public class ReviewsController:ControllerBase
{
    private readonly IReviewsService _reviewsService;

    public ReviewsController(IReviewsService reviewsService)
    {
        _reviewsService = reviewsService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateReviews(Reviews reviews)
    {
        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, easternZone);
        reviews.Time = easternTime;
       Reviews comment = await _reviewsService.CreateReview(reviews);
       return Ok(new {message="successfully"});
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReviewsByProduct(int id)
    {
        List<Reviews>? reviews = await _reviewsService.GetReviewsByProduct(id);
        if (reviews == null)
        {
            return NotFound("reviews Not Found");
        }
        return Ok(reviews);
    }
}