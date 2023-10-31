namespace Application.User.List;

public record ListUserResponse
{
    public string Id { get; set; }
    
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
}