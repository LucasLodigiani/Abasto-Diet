using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, int>
    {
        private readonly IApplicationDbContext _context;

        public AddUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = new UserEntity
            {

            };

            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync(cancellationToken);

            return 1;

        }

    }
}
