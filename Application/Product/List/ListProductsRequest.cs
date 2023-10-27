using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.List
{
    public record ListProductsRequest : IRequest<IEnumerable<ListProductsResponse>>
    {

    }
}
