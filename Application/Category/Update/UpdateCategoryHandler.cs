using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Category.Update;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (category is null)
        {
            throw new NotFoundException("La categoria a modificar no ha sido encontrada");
        }

        _mapper.Map(request, category);

        _context.Categories.Update(category);

        await _context.SaveChangesAsync(cancellationToken);
        
    }
}