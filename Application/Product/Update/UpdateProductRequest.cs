using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Product.Update;

public record UpdateProductRequest : IRequest
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public string? Description { get; set; }

    public float? Price { get; set; }

    public string? Weight { get; set; }

    public IFormFile? Image { get; set; }

    public int? CategoryId { get; set; }
}