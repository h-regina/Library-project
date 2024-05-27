using LibraryApp.Shared;
using System.Net.Http.Json;

namespace LibraryApp.UI.Services
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _httpBooks;

        public BooksService(HttpClient httpBooks)
        {
            _httpBooks = httpBooks;
        }

        public async Task AddBooksAsync(Books book)
        {
            await _httpBooks.PostAsJsonAsync("/books", book);
        }

        public async Task DeleteBooksAsync(Guid id)
        {
            await _httpBooks.DeleteAsync($"/books/{id}");
        }

        public async Task<Books> GetBooksAsync(Guid id)
        {
            return await _httpBooks.GetFromJsonAsync<Books>($"/books/{id}");
        }

        public async Task<IEnumerable<Books>> GetBooksAsync()
        {
            return await _httpBooks.GetFromJsonAsync<IEnumerable<Books>>("/books");
        }

        public async Task UpdateBooksAsync(Guid id, Books book)
        {
            await _httpBooks.PutAsJsonAsync($"/books/{id}", book);
        }
    }
}
