using Application.Category.Add;
using Application.Category.List;
using Application.Category.Remove;
using Application.Category.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await Mediator.Send(new ListCategoryRequest()));
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddCategoryRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            await Mediator.Send(request);
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCategoryRequest(id));
            
            return NoContent();
        }
    }
}
