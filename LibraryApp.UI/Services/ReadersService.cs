using LibraryApp.Shared;
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
            try
            {
                await _httpReaders.PostAsJsonAsync("/readers", readers);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteReadersAsync(Guid id)
        {
            try
            {
                await _httpReaders.DeleteAsync($"/readers/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Loaning>> GetLoaningBooksOfReaderc(Guid readerId)
        {
            try
            {
                return await _httpReaders.GetFromJsonAsync<IEnumerable<Loaning>>("/reader");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Readers> GetReadersAsync(Guid id)
        {
            try
            {
                return await _httpReaders.GetFromJsonAsync<Readers>($"/readers/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Readers>> GetReadersAsync()
        {
            try
            {
                return await _httpReaders.GetFromJsonAsync<IEnumerable<Readers>>("/readers");
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateReadersAsync(Guid id, Readers readers)
        {
            try
            {
                await _httpReaders.PutAsJsonAsync($"/readres/{id}", readers);
            }
            catch
            {
                throw;
            }
        }
    }
}
