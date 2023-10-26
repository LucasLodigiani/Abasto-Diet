using Application.User.Add;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddUserRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
