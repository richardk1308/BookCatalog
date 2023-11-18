using AutoMapper;
using BookCatalog.DbContexts;
using BookCatalog.Models;
using BookCatalog.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await this.bookRepository.GetAllBooksAsync();
            return Ok(this.mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{bookId}", Name = "GetBook")]
        public async Task<ActionResult<BookDto>> GetBook(int bookId)
        {
            var book = await bookRepository.GetBookAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(BookForCreationDto bookForCreation)
        {
            var mappedBook = mapper.Map<Entities.Book>(bookForCreation);

            bookRepository.AddBook(mappedBook);
            await bookRepository.SaveChangesAsync();

            var createdBook = mapper.Map<BookDto>(mappedBook);

            return CreatedAtRoute(
                "GetBook",
                new
                {
                    bookId = createdBook.Id
                },
                createdBook);
        }

        [HttpPut("bookId")]
        public async Task<IActionResult> UpdateBook(int bookId, BookForUpdateDto bookForUpdate)
        {
            if (!await bookRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var book = await bookRepository.GetBookAsync(bookId);

            mapper.Map(bookForUpdate, book);

            await bookRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{bookId}")]
        public async Task<ActionResult> PartiallyUpdateBook(
            int bookId,
            JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            if (!await bookRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var bookEntity = await bookRepository.GetBookAsync(bookId);

            var bookToPatch = mapper.Map<BookForUpdateDto>(bookEntity);

            patchDocument.ApplyTo(bookToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(bookToPatch))
            {
                return BadRequest(ModelState);
            }

            mapper.Map(bookToPatch, bookEntity);

            await bookRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            if (!await bookRepository.BookExistsAsync(bookId))
            {
                return NotFound();
            }

            var bookEntity = await bookRepository.GetBookAsync(bookId);
            bookRepository.DeleteBook(bookEntity);

            await bookRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
