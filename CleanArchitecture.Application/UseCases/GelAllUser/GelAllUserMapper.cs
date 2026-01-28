using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GelAllUser;

public sealed class GelAllUserMapper : Profile
{
    public GelAllUserMapper()
    {
        CreateMap<GetAllUserRequest, User>();
        CreateMap<User, GetAllUserResponse>();
    }
}
