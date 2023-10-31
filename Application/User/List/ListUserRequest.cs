using MediatR;

namespace Application.User.List;

public record ListUserRequest : IRequest<IEnumerable<ListUserResponse>>
{
    
}