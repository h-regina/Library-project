using LibraryApp.Shared;

namespace LibraryApp.UI.Services
{
    public interface IReadersService
    {
        Task AddReadersAsync(Readers readers);

        Task<Readers> GetReadersAsync(Guid id);

        Task UpdateReadersAsync(Guid id,Readers readers);

        Task DeleteReadersAsync(Guid id);

        Task<IEnumerable<Readers>> GetReadersAsync();

        Task<IEnumerable<Loaning>> GetLoaningBooksOfReaderc(Guid readerId);

    }
}
