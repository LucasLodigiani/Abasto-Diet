using Application.User.Add;
using Application.User.Delete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<(int, string)>> Create([FromBody] AddUserRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> Delete(string userId)
        {
            var deleteUserRequest = new DeleteUserRequest { UserId = userId };
            return await Mediator.Send(deleteUserRequest);
        }
    }
}
