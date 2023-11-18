using BookCatalog.Models;

namespace BookCatalog
{
    public class BooksDataStore
    {
        public List<BookDto> Books { get; set; }

        public static BooksDataStore Instance { get; set; } = new BooksDataStore();

        public BooksDataStore()
        {
            Books = new List<BookDto>()
            {
                new BookDto()
                {
                    Id = 1,
                    Title = "Keď báčik z Chochoľova umrie",
                    AuthorName = "Martin Kukučín"
                },
                new BookDto()
                {
                    Id = 2,
                    Title = "The Lord of the Rings",
                    AuthorName = "J. R. R. Tolkien"
                },
                new BookDto()
                {
                    Id = 3,
                    Title = "Myšlienky k sebe samému",
                    AuthorName = "Marcus Aurelius"
                }
            };
        }
    }
}
