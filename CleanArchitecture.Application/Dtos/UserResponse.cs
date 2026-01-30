namespace CleanArchitecture.Application.Dtos;

public record class UserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public bool Ativo { get; set; }
}
