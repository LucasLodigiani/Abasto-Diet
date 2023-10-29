using System.Security.Claims;

namespace Domain.Interfaces;

public interface IJwtService
{
    public string GenerateToken(IEnumerable<Claim> claimsForToken);
}