using LibraryApp.Shared;

namespace LibraryApp
{
    public interface ILoaningsService
    {
        Task Add(Loaning loaning);

        Task Delete(Guid id);

        Task Update(Loaning loaning);

        Task<Loaning> Get(Guid id);
    }
}
