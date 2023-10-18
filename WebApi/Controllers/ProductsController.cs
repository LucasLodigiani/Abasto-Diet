using Application.Product.Add;
using Application.Product.List;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ProductsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] AddProductRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await Mediator.Send(new GetProductsRequest());
        }
    }
}
