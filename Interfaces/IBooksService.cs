using Codingchallenge.Models;

namespace Codingchallenge.Interfaces
{
    public interface IBooksService
    {
        Task<Books> AddBook(Books Book);
        Task<Books?> DeleteBook(int BookId);
        Task<Books?> GetBook(int BookId);
        Task<List<Books>?> GetAllBooks();
        Task<Books> UpdateBook(Books Book);
    }
}
