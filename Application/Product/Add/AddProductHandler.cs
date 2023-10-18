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
        private readonly IFileService _fileService;

        public AddProductHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        public async Task<int> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {

            var newProduct = new ProductEntity
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Weight = request.Weight,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow,
            };

            string imageUrl = await _fileService.SaveImageAsync(request.Image);
        
            newProduct.ImageUrl = imageUrl;

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync(cancellationToken);

            return newProduct.Id;
        }
    }
}
