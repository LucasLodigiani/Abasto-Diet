using MediatR;

namespace Microsoft.Extensions.DependencyInjection.Category.Remove;

public record RemoveCategoryRequest : IRequest<int>
{
    public string Name { get; init; }
}