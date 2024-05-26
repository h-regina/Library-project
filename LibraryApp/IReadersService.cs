using LibraryApp.Shared;

namespace LibraryApp
{
    public interface IReadersService
    {
        Task Add(Readers readers);

        Task<Readers> Get(Guid id);

        Task Update(Guid id,Readers readers);

        Task Delete(Guid id);

        Task<List<Readers>> GetAll();

        Task<List<Loaning>> GetLoaningBooksOfReader(Guid ReaderId);

    }
}
