using MediatR;

namespace Application.User.Update;

public record UpdateUserRequest : IRequest
{
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Password { get; set; }
    
}