using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.User.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, IdentityResult>
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        public AddUserHandler(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {

            var newUser = _mapper.Map<UserEntity>(request);
            
            var result = await _userManager.CreateAsync(newUser, request.Password);

            return result;
        }
    }
}
