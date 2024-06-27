using BookStore.DataAccess.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEnity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
            };

            await _dbContext.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _dbContext.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(b => b.Title, b => title)
                                          .SetProperty(b => b.Description, b => description)
                                          .SetProperty(b => b.Price, b => price));

            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
