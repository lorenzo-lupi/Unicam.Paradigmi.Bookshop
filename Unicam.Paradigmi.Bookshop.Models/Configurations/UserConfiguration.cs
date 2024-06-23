using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(u => u.Id);
        DefineProperties(builder);
    }
    
    private static void DefineProperties(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(65);
        builder.Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(65);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(320);
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255);
    }
}