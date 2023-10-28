using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.User.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, (int, string)>
    {
        private readonly ILogger<AddUserHandler> _logger;
        private readonly UserManager<UserEntity> _userManager;

        public AddUserHandler(UserManager<UserEntity> userManager, ILogger<AddUserHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<(int,string)> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = new UserEntity
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                return (1, "Creado exitosamente"); //resultado exitoso
            }
            else
            {
                return (0, "Creación fallida");

            }
        }
    }
}
