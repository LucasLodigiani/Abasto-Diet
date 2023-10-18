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
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string Weight { get; set; }

        public int CategoryId { get; set; }

        public IFormFile Image { get; set; }
    }
}
