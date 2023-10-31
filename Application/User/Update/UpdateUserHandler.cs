using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User.Update;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public UpdateUserHandler(UserManager<UserEntity> userManager, ICurrentUserService currentUserService, IMapper mapper, IApplicationDbContext context)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _mapper = mapper;
        _context = context;
    }
    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        
        var user = await _userManager.FindByIdAsync(userId);

        bool passwordMatch = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordMatch)
        {
            throw new UnauthorizedAccessException("Contraseña incorrecta!");
        }
        
        _mapper.Map(request, user);

        await _userManager.UpdateAsync(user);
        
    }
}