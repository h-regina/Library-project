using System.Net.Http.Json;
using LibraryApp.Shared;

namespace LibraryApp.UI.Services
{
    public class LoaningsService : ILoaningsService
    {
        private readonly HttpClient _httpLoaning;

        public LoaningsService(HttpClient httpLoaning)
        {
            _httpLoaning = httpLoaning;
        }

        public async Task AddLoaningAsync(Loaning loaning)
        {
            await _httpLoaning.PostAsJsonAsync("/loanings/add", loaning);
        }

        public async Task DeleteLoaningAsync(Guid id)
        {
            await _httpLoaning.DeleteAsync($"/loanings/{id}");
        }

        public async Task UpdateLoaningAsync(Loaning loaning)
        {
            await _httpLoaning.PutAsJsonAsync("loanings", loaning);
        }

        public async Task<Loaning> GetLoaningAsync(Guid id)
        {
            return await _httpLoaning.GetFromJsonAsync<Loaning>("/loanings/list");
        }

        public async Task<IEnumerable<LoaningWithBook>> GetLoaningsWithBooksAsync()
        {
            var loanings = await _httpLoaning.GetFromJsonAsync<IEnumerable<Loaning>>("/loanings");
            var books = await _httpLoaning.GetFromJsonAsync<IEnumerable<Books>>("/books");

            var loaningWithBooks = from loaning in loanings
                                   join book in books on loaning.InventoryNumber equals book.InventoryNumber
                                   select new LoaningWithBook
                                   {
                                       Loaning = loaning,
                                       Book = book
                                   };

            return loaningWithBooks;
        }
    }
}
