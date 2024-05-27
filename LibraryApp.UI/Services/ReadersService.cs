using LibraryApp.Shared;
using System.IO.Pipelines;
using System.Net.Http.Json;

namespace LibraryApp.UI.Services
{
    public class ReadersService : IReadersService
    {
        private readonly HttpClient _httpReaders;

        public ReadersService(HttpClient httpReaders)
        {
            _httpReaders = httpReaders;
        }

        public async Task AddReadersAsync(Readers readers)
        {
            await _httpReaders.PostAsJsonAsync("/readers", readers);
        }

        public async Task DeleteReadersAsync(Guid id)
        {
            await _httpReaders.DeleteAsync($"/readers/{id}");
        }

        public async Task<IEnumerable<Loaning>> GetLoaningBooksOfReaderc(Guid readerId)
        {
            return await _httpReaders.GetFromJsonAsync<IEnumerable<Loaning>>($"/readers/{readerId}/loanings");
           
        }

        public async Task<Readers> GetReadersAsync(Guid id)
        {
            return await _httpReaders.GetFromJsonAsync<Readers>($"/readers/{id}");
            
        }

        public async Task<IEnumerable<Readers>> GetReadersAsync()
        {
            return await _httpReaders.GetFromJsonAsync<IEnumerable<Readers>>("/readers");
           
        }

        public async Task UpdateReadersAsync(Guid id, Readers readers)
        {
             await _httpReaders.PutAsJsonAsync($"/readers/{id}", readers);
        }
    }
}
