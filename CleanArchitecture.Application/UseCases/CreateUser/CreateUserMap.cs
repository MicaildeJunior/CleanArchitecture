using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed class CreateUserMap : Profile
{
    public CreateUserMap()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}
