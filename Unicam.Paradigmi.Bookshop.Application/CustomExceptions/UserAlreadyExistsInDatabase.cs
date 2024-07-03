namespace Unicam.Paradigmi.Bookshop.Application.CustomExceptions;

public class UserAlreadyExistsInDatabase : ArgumentException
{
    public UserAlreadyExistsInDatabase(string email)
        : base($"{email} already exists in database")
    {
    }
}