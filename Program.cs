using practice_code_first.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace practice_code_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                var service = new ServiceBook(context);
                var newBook = new Book
                {
                    Title = "Introduction to C# Programming",
                    Author = "John Doe",
                    Available = true
                };
                service.AddBook(newBook,1);
                service.IssueBook(newBook.BookId, "Alice Smith");
                int publicationIdToReturn = 1; 
                service.ReturnBook(publicationIdToReturn);
                var searchResults = service.SearchBooks("Programming");
                Console.WriteLine("Books found by search:");
                foreach (var book in searchResults)
                {
                    Console.WriteLine($"{book.Title} by {book.Author}");
                }
                var availableBooks = service.GetAvailableBooks();
                Console.WriteLine("\nAvailable books:");
                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author}");
                }
                var booksIssuedToReader = service.GetBooksIssuedToReader("Alice Smith");
                Console.WriteLine("\nBooks issued to Alice Smith:");
                foreach (var publication in booksIssuedToReader)
                {
                    Console.WriteLine($"{publication.Book.Title} (Issued on {publication.IssueTime}, Returned on {publication.ReturnTime})");
                }
                var popularBooks = service.GetMostPopularBooks();
                Console.WriteLine("\nMost popular books:");
                foreach (var book in popularBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author}");
                }
                var booksIssuedLastMonth = service.GetBooksIssuedLastMonth();
                Console.WriteLine("\nBooks issued in the last month:");
                foreach (var publication in booksIssuedLastMonth)
                {
                    Console.WriteLine($"{publication.Book.Title} (Issued on {publication.IssueTime}, Returned on {publication.ReturnTime})");
                }
                int year = 2023; 
                int totalBooksIssued = service.GetTotalBooksIssuedInYear(year);
                Console.WriteLine($"\nTotal books issued in {year}: {totalBooksIssued}");
                var popularAuthors = service.GetPopularAuthors();
                Console.WriteLine("\nPopular authors:");
                foreach (var author in popularAuthors)
                {
                    Console.WriteLine(author);
                }
                var popularBooksOfEachAuthor = service.GetMostPopularBookOfEachAuthor();
                Console.WriteLine("\nMost popular book of each author:");
                foreach (var book in popularBooksOfEachAuthor)
                {
                    Console.WriteLine($"{book.Title} by {book.Author}");
                }
            }
        }
    }
}
