using LibraryApp.Shared;
using System.Net.Http.Json;

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
            await _httpLoaning.PostAsJsonAsync("/loanings",loaning);
        }
        
        public async Task DeleteLoaningAsync(DateTime dateTime)
        {
            await _httpLoaning.DeleteAsync($"/loanings/{dateTime}");
        }

        public async Task UpdateLoaningAsync(Loaning loaning)
        {
            await _httpLoaning.PutAsJsonAsync("loanings",loaning);
        }

        public async Task<Loaning> GetLoaningAsync(Guid id)
        {
            return await _httpLoaning.GetFromJsonAsync<Loaning>($"/loanings/{id}");
        }
    }
}
