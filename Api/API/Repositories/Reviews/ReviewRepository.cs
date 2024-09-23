using API.Configuration;
using API.Entities.Reviews;
using API.Repositories.Reviews.Interfaces;

namespace API.Repositories.Reviews;

public class ReviewRepository : IReviewRepository
{
    protected readonly AppDbContext Context;

    public ReviewRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task Create(Review review)
    {
        await Context.Set<Review>().AddAsync(review);
        await Context.SaveChangesAsync();
    }
}