using MediatR;

namespace Application.User.Get;

public record GetUserRequest(string Id) : IRequest<GetUserResponse>;
