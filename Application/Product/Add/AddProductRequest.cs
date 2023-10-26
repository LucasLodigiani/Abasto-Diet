using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Add
{
    public record AddProductRequest : IRequest<int>
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public float Price { get; init; }

        public string Weight { get; init; }

        public int CategoryId { get; init; }

        public IFormFile Image { get; set; }
    }
}
