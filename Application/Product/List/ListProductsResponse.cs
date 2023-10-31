namespace Application.Product.List;

public record ListProductsResponse
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    public float Price { get; set; }

    public string Weight { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
    
    public string CategoryName { get; set; }
    
}