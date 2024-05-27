using LibraryApp.Shared;
namespace LibraryApp.UI.Services
{
    public interface ILoaningsService
    {
        Task AddLoaningAsync(Loaning loaning);

        Task DeleteLoaningAsync(Guid id);

        Task UpdateLoaningAsync(Loaning loaning);

        Task<Loaning> GetLoaningAsync(Guid id);

        Task<IEnumerable<LoaningWithBook>> GetLoaningsWithBooksAsync();

    }
}
