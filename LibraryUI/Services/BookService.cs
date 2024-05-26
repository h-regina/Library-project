using LibraryApp.Shared;
using System.Net.Http.Json;

namespace LibraryApp.UI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpBooks;

        public BookService(HttpClient httpBooks)
        {
            _httpBooks = httpBooks;
        }

        public async Task AddBooksAsync(Books book)
        {
            try
            {
                await _httpBooks.PostAsJsonAsync("/Books", book);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteBooksAsync(Guid id)
        {
            try
            {
                await _httpBooks.DeleteAsync($"/Books/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Books> GetBooksAsync(Guid id)
        {
            try
            {
                return await _httpBooks.GetFromJsonAsync<Books>($"/Books/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Books>> GetBooksAsync()
        {
            try
            {
                return await _httpBooks.GetFromJsonAsync<IEnumerable<Books>>("/Books");
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateBooksAsync(Guid id, Books book)
        {
            try
            {
                await _httpBooks.PutAsJsonAsync($"/Books/{id}", book);
            }
            catch
            {
                throw;
            }
        }

    }
}

