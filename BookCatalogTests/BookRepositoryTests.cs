using BookCatalog.DbContexts;
using BookCatalog.Entities;
using BookCatalog.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BookCatalogTests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private IBookRepository _bookRepository = default!;
        private Mock<BookContext> _mockBookContext = default!;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptions<BookContext>();
            _mockBookContext = new Mock<BookContext>(options);

            IList<Book> books = new List<Book>()
            {
                new Book("name1", "title1")
                {
                    Id = 1,
                    Description = "description1"
                },
                new Book("name2", "title2")
                {
                    Id = 2,
                    Description = "description2"
                },
                new Book("name3", "title3")
                {
                    Id = 3,
                    Description = "description3"
                },
                new Book("name4", "title4")
                {
                    Id = 4,
                    Description = "description4"
                },
            };
            _mockBookContext.Setup(x => x.Books).ReturnsDbSet(books);

            _bookRepository = new BookRepository(_mockBookContext.Object);
        }

        [TestMethod]
        public async Task BookRepository_GetSecondBook_Success()
        {
            // Arrange
            int bookId = 2;

            // Act
            var book = await _bookRepository.GetBookAsync(bookId);

            // Assert
            Assert.AreEqual(bookId, book.Id);
        }

        [TestMethod]
        public async Task BookRepository_GetNonExistingBook_NullReturned()
        {
            // Arrange
            int bookId = 10;

            // Act
            var book = await _bookRepository.GetBookAsync(bookId);

            // Assert
            Assert.AreEqual(null, book);
        }

        [TestMethod]
        public async Task BookRepository_GetAllBooks_Success()
        {
            // Arrange
            int bookCount = 4;

            // Act
            var books = await _bookRepository.GetAllBooksAsync();

            // Assert
            Assert.AreEqual(bookCount, books.Count());
        }

        [TestMethod]
        public void BookRepository_AddBook_Success()
        {
            // Arrange
            var bookToAdd = new Book("New Author", "New Title");

            // Act
            _bookRepository.AddBook(bookToAdd);

            // Assert
            _mockBookContext.Verify(bookContext => bookContext.Books.Add(bookToAdd), Times.Once);
        }

        [TestMethod]
        public async Task BookRepository_BookExists_Success()
        {
            // Arrange
            int bookId = 2;

            // Act
            bool result = await _bookRepository.BookExistsAsync(bookId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task BookRepository_DeleteBook_Success()
        {
            // Arrange
            int bookId = 4;
            var book = await _bookRepository.GetBookAsync(bookId);

            // Act
            _bookRepository.DeleteBook(book);

            // Assert
            _mockBookContext.Verify(bookContext => bookContext.Books.Remove(book), Times.Once);
        }

        [TestMethod]
        public async Task BookRepository_SaveChanges_Success()
        {
            // Arrange

            // Act
            await _bookRepository.SaveChangesAsync();

            // Assert
            _mockBookContext.Verify(bookContext => bookContext.SaveChangesAsync(default), Times.Once);
        }
    }
}