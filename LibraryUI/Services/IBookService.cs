using LibraryApp.Shared;

namespace LibraryApp.UI.Services
{
    public interface IBookService
    {
        Task AddBooksAsync(Books book);

        Task<Books> GetBooksAsync(Guid id);

        Task UpdateBooksAsync(Books book);

        Task DeleteBooksAsync(Guid id);

        Task<IEnumerable<Books>> GetBooksAsync();

    }
}
