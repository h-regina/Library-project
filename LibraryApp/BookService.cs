using LibraryShared;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace LibraryApp
{
    public class BookService : IBooksService
    {
        private readonly LibraryContext _context;
        private readonly ILogger<BookService> _logger;

        public BookService(ILogger<BookService> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Add(Books books)
        {
            try
            {
                await _context.Books.AddRangeAsync(books);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Book added: @{InventoryNumber}", books.InventoryNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while adding book");
                throw ex;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var book = await Get(id);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Book removed: @{InventoryNumber}", book);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while removing book");
                throw ex;
            }
        }

        public async Task<Books> Get(Guid id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                _logger.LogInformation("Books retrieved: {@Books}", book);
                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while querying the books");
                throw ex;
            }
        }

        public async Task<List<Books>> GetAll()
        {
           return await _context.Books.ToListAsync();
        }

        public async Task Update(Books newBooks)
        {
            try
            {
                var book = await Get(newBooks.InventoryNumber);
                book.BookTitle = newBooks.BookTitle;
                book.Author = newBooks.Author;
                book.Publisher = newBooks.Publisher;
                book.PublicationYear = newBooks.PublicationYear;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating book");
                throw ex;
            }
        }
    }
}
