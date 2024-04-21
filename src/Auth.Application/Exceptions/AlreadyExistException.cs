namespace Auth.Application.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string name , object key)
    : base($"Entity: {name} ({key}) already exists")
    {
        
    }
}