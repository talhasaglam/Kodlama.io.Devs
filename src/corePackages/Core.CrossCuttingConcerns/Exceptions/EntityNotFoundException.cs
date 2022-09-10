namespace Core.CrossCuttingConcerns.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(NotFoundMessage(message))
    {

    }
    private static string NotFoundMessage(string message) { return message + " Entity Not Found.";}
}