namespace Application.User.Get;

public record GetUserResponse
{
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
}