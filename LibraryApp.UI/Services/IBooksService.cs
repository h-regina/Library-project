using LibraryApp.Shared;

namespace LibraryApp.UI.Services
{
    public interface IBooksService
    {
        Task AddBooksAsync(Books book);

        Task<Books> GetBooksAsync(Guid id);

        Task UpdateBooksAsync(Guid id,Books book);

        Task DeleteBooksAsync(Guid id);

        Task<IEnumerable<Books>> GetBooksAsync();

    }
}
