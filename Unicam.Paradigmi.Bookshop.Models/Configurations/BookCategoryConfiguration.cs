using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Configurations;

public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.ToTable("BookCategories")
            .HasKey(r => new { r.BookId, r.CategoryId });
        DefineRelations(builder);
    }

    private static void DefineRelations(EntityTypeBuilder<BookCategory> builder)
    {
        builder.HasOne(r => r.Book)
            .WithMany(b => b.Categories)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(r => r.Category)
            .WithMany()
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}