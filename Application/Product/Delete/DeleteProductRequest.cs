using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Delete
{
    public record DeleteProductRequest : IRequest<bool>
    {
        public int ProductId { get; set; } 
    }
}
