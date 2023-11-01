using Application.Product.Add;
using Application.Product.Delete;
using Application.Product.List;
using Application.Product.Update;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class ProductsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] AddProductRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductRequest request)
        {
            await Mediator.Send(request);
            
            return NoContent();
        }
        

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ListProductsResponse>> List()
        {
            return await Mediator.Send(new ListProductsRequest());
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> Delete(int productId)
        {
            var deleteProductRequest = new DeleteProductRequest { ProductId = productId };
            return await Mediator.Send(deleteProductRequest);
        }

    }
}
