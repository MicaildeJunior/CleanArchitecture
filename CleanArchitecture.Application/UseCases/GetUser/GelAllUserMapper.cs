using AutoMapper;
using CleanArchitecture.Application.UseCases.GelAllUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetUser;

public sealed class GelAllUserMapper : Profile
{
    public GelAllUserMapper()
    {
        CreateMap<GetAllUserRequest, User>();
        CreateMap<User, GetAllUserResponse>();
    }
}
