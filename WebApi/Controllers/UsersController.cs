using Application.User.Add;
using Application.User.Delete;
using Application.User.Get;
using Application.User.List;
using Application.User.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await Mediator.Send(new ListUserRequest()));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetUserResponse>> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetUserRequest(id)));
        }
        
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            await Mediator.Send(request);
            
            return NoContent();
        }
        

        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> Delete(string userId)
        {
            var deleteUserRequest = new DeleteUserRequest { UserId = userId };
            return await Mediator.Send(deleteUserRequest);
        }
    }
}
