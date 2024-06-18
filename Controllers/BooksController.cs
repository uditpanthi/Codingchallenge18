using Codingchallenge.Interfaces;
using Codingchallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codingchallenge.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        public async Task<ActionResult<Books>> AddBooks(Books book)
        {
            try
            {
                var newBook = await _booksService.AddBook(book);
                return Ok(newBook);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<Books>> DeleteBook(int bookId)
        {
            var deletedbook = await _booksService.DeleteBook(bookId);
            if (deletedbook == null)
            {
                return NotFound();
            }
            return Ok(deletedbook);
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<Books>> GetUser(int bookId)
        {
            var book = await _booksService.GetBook(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult<Books>> UpdateUser(int bookId,Books book)
        {
            if(bookId!=book.Id)
            {
                return BadRequest("Not Found");
            }
            try
            {
                var updatedBook = await _booksService.UpdateBook(book);
                if(updatedBook == null)
                {
                    return NotFound();
                }
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
