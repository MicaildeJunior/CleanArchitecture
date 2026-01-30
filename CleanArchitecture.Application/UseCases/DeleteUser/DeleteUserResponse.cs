using CleanArchitecture.Application.Dtos;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public sealed record DeleteUserResponse : UserResponse
{
    public DateTimeOffset? DateDeleted { get; set; }
}
