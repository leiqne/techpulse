using API.Entities.Products;
using API.Entities.Reviews.Interfaces;
using API.Entities.Users;

namespace API.Entities.Reviews;

public class Review
{
    public Review()
    {
        Stars = new StarNumber();
        Content = new ReviewContent();
        UId = 0;
        ProdId = 0;
    }

    public Review(ReviewResource reviewResource)
    {
        Stars = new StarNumber(reviewResource.Stars);
        Content = new ReviewContent(reviewResource.Content);
        UId = reviewResource.UId;
        ProdId = reviewResource.ProdId;
    }

    public int Id { get; set; }
    public StarNumber Stars { get; set; }
    public ReviewContent Content { get; set; }
    public int UId { get; set; }
    public int ProdId { get; set; }
    
    public User User { get; set; }
    public Product Product { get; set; }
}