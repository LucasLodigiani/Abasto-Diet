using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Category.List;

public class ListCategoryHandler : IRequestHandler<ListCategoryRequest, IEnumerable<ListCategoryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public ListCategoryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<IEnumerable<ListCategoryResponse>> Handle(ListCategoryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.ToListAsync();

        var response = _mapper.Map<IEnumerable<ListCategoryResponse>>(categories);

        return response;
        
    }
}