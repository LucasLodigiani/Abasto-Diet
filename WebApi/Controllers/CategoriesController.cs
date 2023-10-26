using Application.Category.Add;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddCategoryRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
