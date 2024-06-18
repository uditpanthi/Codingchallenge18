using Codingchallenge.Interfaces;
using Codingchallenge.Models;
using Codingchallenge.Repositories;
using PracticeTest.Exceptions;
using PracticeTest.Interfaces;

namespace Codingchallenge.Services
{
    public class BooksService : IBooksService
    {
        private readonly BooksRepository _booksRepository;
        public BooksService(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<Books> AddBook(Books Book)
        {
            return await _booksRepository.Add(Book);
        }

        public async Task<Books?> DeleteBook(int BookId)
        {
            return await _booksRepository.Delete(BookId);
        }

        public async Task<List<Books>?> GetAllBooks()
        {
            return await _booksRepository.GetAll();
        }

        public async Task<Books?> GetBook(int BookId)
        {
            try
            {
                return await _booksRepository.Get(BookId);
            }
            catch(NotSupportedException)
            {
                return null;
            }
        }

        public async Task<Books> UpdateBook(Books book)
        {
            var books = await _booksRepository.Get(book.Id);
            if (books != null)
            {
                books.Title = book.Title;
                books.Author = book.Author;
                books.Genre = book.Genre;
                books.PublicationYear = book.PublicationYear;
                books.Publisher = book.Publisher;
                books.TotalCopies = book.TotalCopies;
                return await _booksRepository.Update(books);
            }
            throw new NoSuchBookException();
        }
    }
}
