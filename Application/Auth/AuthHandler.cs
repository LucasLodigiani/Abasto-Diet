using System.Security.Claims;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Application.Auth;

public class AuthHandler : IRequestHandler<AuthRequest, AuthResponse>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IJwtService _jwtService;

    public AuthHandler(UserManager<UserEntity> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }
    public async Task<AuthResponse> Handle(AuthRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
        {
            throw new NotFoundException("El usuario ingresado no ha sido encontrado");
        }

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedAccessException("El nombre de usuario o contraseña ingresados son incorrectos.");
        }
        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new Claim("unique_id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, userRoles.First()),
        };

        string Token = _jwtService.GenerateToken(authClaims);

        var response = new AuthResponse
        {
            Jwt = Token,
        };

        return response;
    }
}