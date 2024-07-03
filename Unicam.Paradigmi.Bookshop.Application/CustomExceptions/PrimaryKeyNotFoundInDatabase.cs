namespace Unicam.Paradigmi.Bookshop.Application.CustomExceptions;

public class PrimaryKeyNotFoundInDatabase : ArgumentException
{
    public PrimaryKeyNotFoundInDatabase(string message)
        : base(message)
    {
    }
}