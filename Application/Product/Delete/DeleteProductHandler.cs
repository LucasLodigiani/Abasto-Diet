using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
