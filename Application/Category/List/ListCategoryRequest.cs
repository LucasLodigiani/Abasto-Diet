using MediatR;

namespace Application.Category.List;

public record ListCategoryRequest : IRequest<IEnumerable<ListCategoryResponse>>
{
    
}