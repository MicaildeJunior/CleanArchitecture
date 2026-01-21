namespace CleanArchitecture.Domain.Exceptions;

public class UserNotFoundException(Guid id) : NotFoundException($"Usuário com ID {id} não encontrado.")
{
}
