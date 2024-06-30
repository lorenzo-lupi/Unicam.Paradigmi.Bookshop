namespace Unicam.Paradigmi.Bookshop.Application.CustomExceptions;

public class CategoryAlreadyExistsInDatabase : ArgumentException
{
    public CategoryAlreadyExistsInDatabase(string name) 
        : base($"category {name} already exists in the database")
    {
        
    }
}