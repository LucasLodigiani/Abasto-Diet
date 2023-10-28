using MediatR;

namespace Application.Category.Remove;

public record RemoveCategoryRequest : IRequest<int>
{
    public string Name { get; init; }
}