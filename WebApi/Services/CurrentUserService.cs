using Domain.Interfaces;
using System.Net;

namespace WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId => _httpContextAccessor.HttpContext?.User.FindFirst("unique_id").Value;

        public IPAddress? UserClientIpAddress => _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

    }
}
