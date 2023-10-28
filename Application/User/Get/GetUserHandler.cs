using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User.Get;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMapper _mapper;

    public GetUserHandler(UserManager<UserEntity> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        if (user is null)
        {
            throw new NotFoundException("No se ha encontrado el usuario especificado");
        }
        
        var response = _mapper.Map<GetUserResponse>(user);
        
        return response;
    }
}