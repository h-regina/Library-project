using LibraryApp.Shared;

namespace LibraryApp.UI.Services
{
    public interface IReaderService
    {
        Task AddReadersAsync(Readers readers);

        Task<Readers> GetReadersAsync(Guid id);

        Task UpdateReadersAsync(Readers readers);

        Task DeleteReadersAsync(Guid id);

        Task<IEnumerable<Readers>> GetReadersAsync();

    }
}
