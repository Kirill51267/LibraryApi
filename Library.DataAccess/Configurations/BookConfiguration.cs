using BookStore.DataAccess.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEnity>
    {
        public void Configure(EntityTypeBuilder<BookEnity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(Book.MAX_TITLE_LENGHT)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();
        }
    }
}
