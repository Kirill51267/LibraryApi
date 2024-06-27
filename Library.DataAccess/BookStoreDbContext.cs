using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) 
            : base(options) 
        { 
            Database.EnsureCreated();
        }

        public DbSet<BookEnity> Books { get; set; }

    }
}
