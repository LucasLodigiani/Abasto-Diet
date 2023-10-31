using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Update;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public UpdateProductHandler(IApplicationDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }
    public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product is null)
        {
            throw new NotFoundException("El producto especificado no ha sido encontrado.");
        }
        
        //Mapeo manual para dos campos, esto es porque automapper tiene problemas con las propiedades que son int o float.
        if (request.Price.HasValue && request.Price.Value != 0)
        {
            product.Price = request.Price.Value;
        }
        
        if (request.CategoryId.HasValue && request.CategoryId.Value != 0)
        {
            product.CategoryId = request.CategoryId.Value;
        }

        _mapper.Map(request, product);

        if (request.Image != null)
        {
            product.ImageUrl = await _fileService.SaveImageAsync(request.Image);
        }

        _context.Products.Update(product);

        await _context.SaveChangesAsync(cancellationToken);
        
    }
    
}