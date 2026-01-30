using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetUser;

public sealed class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<GetUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
