using API.Entities.Reviews;
using API.Entities.Reviews.Interfaces;

namespace API.Services.Reviews.Interfaces;

public interface IReviewService
{
    Task<Review?> Handle(ReviewResource reviewResource);
}