using Codingchallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeTest.Context;
using PracticeTest.Exceptions;
using PracticeTest.Interfaces;

namespace Codingchallenge.Repositories
{
    public class BooksRepository : IRepository<int, Books>
    {
        private readonly ChallengeContext _context;
        public BooksRepository(ChallengeContext context)
        {
            _context = context;
        }

        public async Task<Books> Add(Books item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Books?> Delete(int key)
        {
            var book = await Get(key);
            _context?.books.Remove(book);
            _context?.SaveChanges();
            return book;
        }

        public async Task<Books?> Get(int key)
        {
                var getBook = await _context.books.FindAsync(key);
                if (getBook != null)
                {
                    return getBook;
                }
                throw new NoSuchBookException();
         }

            public async Task<List<Books>?> GetAll()
        {
            var books = await _context.books.ToListAsync();
            return books;
        }

        public async Task<Books> Update(Books item)
        {

            var book = await Get(item.Id);
            _context.Entry<Books>(book).State = EntityState.Modified;
            _context.SaveChanges();
            return book;
            //var book = await Get(item.Id);
            //if (book != null)
            //{
            //    _context.Entry<Books>(item).State = EntityState.Modified;
            //    _context.SaveChanges();
            //    return item;
            //}
            //return null;
        }
    }
}
