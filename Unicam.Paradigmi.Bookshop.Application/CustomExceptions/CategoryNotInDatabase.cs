namespace Unicam.Paradigmi.Bookshop.Application.CustomExceptions;

public class CategoryNotInDatabase : ArgumentException
{
    public CategoryNotInDatabase(string name)
        : base($"category {name} is not present in the database")
    {
        
    }
}