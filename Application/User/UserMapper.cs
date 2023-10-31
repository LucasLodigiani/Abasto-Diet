using Application.User.Add;
using Application.User.Get;
using Application.User.List;
using Application.User.Update;
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
        
        //Update
        CreateMap<UpdateUserRequest, UserEntity>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));;
        
        //List
        CreateMap<UserEntity, ListUserResponse>();
    }
}