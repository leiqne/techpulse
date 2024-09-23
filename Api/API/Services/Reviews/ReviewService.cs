using API.Entities.Reviews;
using API.Entities.Reviews.Interfaces;
using API.Repositories.Products.Interfaces;
using API.Repositories.Reviews.Interfaces;
using API.Repositories.Users.Interfaces;
using API.Services.Reviews.Interfaces;

namespace API.Services.Reviews;

public class ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, IProductRepository productRepository) : IReviewService
{
    public async Task<Review?> Handle(ReviewResource reviewResource)
    {
        var user = await userRepository.SearchById(reviewResource.UId);
        var product = await productRepository.SearchById(reviewResource.ProdId);

        if (user == null)
        {
            throw new Exception("Invalid User Id");
        }
        if (product == null)
        {
            throw new Exception("Invalid Product Id");
        }
        if (user == null & product == null)
        {
            throw new Exception("Invalid User Id and Product Id");
        }
        
        var review = new Review(reviewResource);
        await reviewRepository.Create(review);
        return review;
    }
}