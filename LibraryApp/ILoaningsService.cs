using LibraryApp.Shared;

namespace LibraryApp
{
    public interface ILoaningsService
    {
        Task Add(Loaning loaning);

        Task Delete(Loaning loaning);

        Task Update(Loaning loaning);

        Task<Loaning> Get(Guid id);
    }
}
