namespace CleanArchitecture.Domain.Exceptions;

public class NotFoundException(string message) : BaseException(message)
{
}
