using MediatR;

namespace Application.Category.Update;

public record UpdateCategoryRequest : IRequest
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}