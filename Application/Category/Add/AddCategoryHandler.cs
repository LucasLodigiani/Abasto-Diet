using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Add
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, int>
    {
        private readonly IApplicationDbContext _context;
        public AddCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = new CategoryEntity
            {
                Name = request.Name,
            };

            await _context.Categories.AddAsync(newCategory);

            await _context.SaveChangesAsync(cancellationToken);

            return newCategory.Id;
        }
    }
}
