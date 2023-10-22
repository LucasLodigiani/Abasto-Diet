using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Add
{
    public record AddCategoryRequest : IRequest<int>
    {
        public string Name { get; init; }
    }
}
