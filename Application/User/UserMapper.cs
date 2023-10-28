using Application.User.Add;
using Application.User.Get;
using AutoMapper;
using Domain.Entities;

namespace Application.User;

public class UserMapper : Profile
{
    public UserMapper()
    {
        //Add
        CreateMap<AddUserRequest, UserEntity>();
        
        //Get
        CreateMap<UserEntity, GetUserResponse>();
    }
}