namespace Unicam.Paradigmi.Bookshop.Models.Entities;

/*Unidirectional many-to-many relationships were introduced in EF Core 7.
 In earlier releases, a private navigation could be used as a workaround.*/
public class BookCategory
{
    public int BookId { get; set; }
    public Book? Book { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}