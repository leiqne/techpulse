namespace API.Entities.Reviews.Interfaces;

public record ReviewResource(int Stars, string Content, int UId, int ProdId);