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
using AutoMapper;

namespace Application.Product.List
{
    public class ListProductsHandler : IRequestHandler<ListProductsRequest, IEnumerable<ListProductsResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ListProductsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListProductsResponse>> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            //En el futuro hay que refactorizar habría que refactorizar esto con AutoMapper, por ahora se queda asi.
            var products = await _context.Products
                .Include(c => c.Category).ToListAsync();

            var response = _mapper.Map<IEnumerable<ListProductsResponse>>(products);
            
            
            return response;
        }
    }
}
