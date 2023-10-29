using Application.Auth;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AuthController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Auth(AuthRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
}