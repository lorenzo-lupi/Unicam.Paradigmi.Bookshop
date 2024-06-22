namespace Unicam.Paradigmi.Bookshop.Models.Entities;

/*Unidirectional many-to-many relationships were introduced in EF Core 7.
 In earlier releases, a private navigation could be used as a workaround.*/
public class BookCategory
{
    public Book Book { get; set; } = null!;
    public Category Category { get; set; } = null!;
}