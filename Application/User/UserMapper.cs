using Application.User.Add;
using AutoMapper;
using Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.User;

public class UserMapper : Profile
{
    public UserMapper()
    {
        //Add
        CreateMap<AddUserRequest, UserEntity>();
    }
}