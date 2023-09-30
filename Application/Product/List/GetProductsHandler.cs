using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.List
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, IEnumerable<ProductEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetProductsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
    }
}
