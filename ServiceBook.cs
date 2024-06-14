using practice_code_first.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace practice_code_first
{
    internal class ServiceBook
    {
        private readonly Model1 _context;

        public ServiceBook(Model1 context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void IssueBook(int bookId, string readerName)
        {
            var book = _context.Books.Find(bookId);
            if (book != null && book.Available)
            {
                book.Available = false;
                _context.Publications.Add(new Publication
                {
                    BookId = bookId,
                    ReaderName = readerName,
                    IssueTime = DateTime.Now
                });
                _context.SaveChanges();
            }
        }

        public void ReturnBook(int publicationId)
        {
            var publication = _context.Publications
                                       .Include(p => p.Book)
                                       .SingleOrDefault(p => p.IssueId == publicationId);
            if (publication != null)
            {
                publication.ReturnTime = DateTime.Now;
                publication.Book.Available = true;
                _context.SaveChanges();
            }
        }

        public IQueryable<Book> SearchBooks(string keyword)
        {
            return _context.Books
                           .Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword));
        }

        public IQueryable<Book> GetAvailableBooks()
        {
            return _context.Books
                           .Where(b => b.Available);
        }

        public IQueryable<Publication> GetBooksIssuedToReader(string readerName)
        {
            return _context.Publications
                           .Include(p => p.Book)
                           .Where(p => p.ReaderName == readerName);
        }

        public IQueryable<Book> GetMostPopularBooks()
        {
            return _context.Publications
                           .GroupBy(p => p.Book)
                           .OrderByDescending(g => g.Count())
                           .Select(g => g.Key);
        }

        public IQueryable<Publication> GetBooksIssuedLastMonth()
        {
            var lastMonth = DateTime.Now.AddMonths(-1);
            return _context.Publications
                           .Include(p => p.Book)
                           .Where(p => p.IssueTime >= lastMonth);
        }

        public int GetTotalBooksIssuedInYear(int year)
        {
            return _context.Publications
                           .Count(p => p.IssueTime.Year == year);
        }

        public IQueryable<string> GetPopularAuthors()
        {
            return _context.Books
                           .GroupBy(b => b.Author)
                           .OrderByDescending(g => g.Count())
                           .Select(g => g.Key);
        }

        public IQueryable<Book> GetMostPopularBookOfEachAuthor()
        {
            return _context.Books
                           .GroupBy(b => b.Author)
                           .Select(g => g.OrderByDescending(b => b.Publications.Count).FirstOrDefault());
        }
    }
}
