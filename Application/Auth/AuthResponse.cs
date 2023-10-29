namespace Application.Auth;

public record AuthResponse
{
    public string Jwt { get; set; }
}