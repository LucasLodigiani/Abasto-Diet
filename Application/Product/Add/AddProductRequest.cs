using MediatR;
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
    }
}
