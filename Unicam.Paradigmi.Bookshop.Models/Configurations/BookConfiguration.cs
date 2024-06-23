using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books")
            .HasKey(b => b.Id);
        DefineProperties(builder);
    }
    
    private static void DefineProperties(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(b => b.Editor)
            .HasMaxLength(255);
    }
}