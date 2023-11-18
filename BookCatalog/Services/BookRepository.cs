using BookCatalog.DbContexts;
using BookCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext bookContext;

        public BookRepository(BookContext bookContext)
        {
            this.bookContext = bookContext ?? throw new ArgumentNullException(nameof(bookContext));
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await bookContext.Books.ToListAsync();
        }

        public async Task<Book?> GetBookAsync(int bookId)
        {
            return await bookContext.Books.Where(book => book.Id == bookId).FirstOrDefaultAsync();
        }

        public void AddBook(Book book)
        {
            bookContext.Books.Add(book);
        }

        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await bookContext.Books.AnyAsync(book => book.Id == bookId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await bookContext.SaveChangesAsync() >= 0;
        }

        public void DeleteBook(Book book)
        {
            bookContext.Books.Remove(book);
        }

    }
}
