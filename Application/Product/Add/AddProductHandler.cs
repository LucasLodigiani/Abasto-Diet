using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Add
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, int>
    {
        private readonly IApplicationDbContext _context;
        public AddProductHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {

            var newProduct = new ProductEntity
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync(cancellationToken);

            return newProduct.Id;
        }
    }
}
