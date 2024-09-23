using API.Entities.Reviews;

namespace API.Repositories.Reviews.Interfaces;

public interface IReviewRepository
{
    Task Create(Review review);
}