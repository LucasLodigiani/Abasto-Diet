using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Category.Remove;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest>
{
    private readonly IApplicationDbContext _context;
    public DeleteCategoryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (category is null)
        {
            throw new NotFoundException("No se ha encontrado la categoría especificada");
        }

        _context.Categories.Remove(category);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}