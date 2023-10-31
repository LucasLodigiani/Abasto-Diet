using MediatR;

namespace Application.Category.Remove;

public record DeleteCategoryRequest(int Id) : IRequest
{
    
}