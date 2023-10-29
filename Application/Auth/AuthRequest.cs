using MediatR;

namespace Application.Auth;

public record AuthRequest : IRequest<AuthResponse>
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
}