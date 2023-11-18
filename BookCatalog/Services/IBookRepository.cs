using BookCatalog.Entities;

namespace BookCatalog.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book?> GetBookAsync(int bookId);

        void AddBook(Book book);

        Task<bool> BookExistsAsync(int bookId);

        Task<bool> SaveChangesAsync();

        void DeleteBook(Book book);
    }
}
