using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.User.List;

public class ListUserHandler : IRequestHandler<ListUserRequest, IEnumerable<ListUserResponse>>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMapper _mapper;
    public ListUserHandler(UserManager<UserEntity> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ListUserResponse>> Handle(ListUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.ToListAsync();

        var response = _mapper.Map<IEnumerable<ListUserResponse>>(users);

        return response;
    }
}