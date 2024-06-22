namespace Unicam.Paradigmi.Bookshop.Models.Entities
{

    public class Book
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime? PublicationDate { get; set; }
        public string? Editor { get; set; }
        public ICollection<Category> Categories { get; set; } = null!;
    }
}