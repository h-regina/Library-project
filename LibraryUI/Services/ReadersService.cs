using LibraryApp.Shared;
using System.Net.Http.Json;

namespace LibraryApp.UI.Services
{
    public class ReadersService : IReaderService
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
                await _httpReaders.PostAsJsonAsync("/Readers", readers);
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
                await _httpReaders.DeleteAsync($"/Readers/{id}");
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
                return await _httpReaders.GetFromJsonAsync<IEnumerable<Loaning>>("/Reader");
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
                return await _httpReaders.GetFromJsonAsync<Readers>($"/Readers/{id}");
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
                return await _httpReaders.GetFromJsonAsync<IEnumerable<Readers>>("/Readers");
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
                await _httpReaders.PutAsJsonAsync($"/Readres/{id}", readers);
            }
            catch
            {
                throw;
            }
        }
    }
}
