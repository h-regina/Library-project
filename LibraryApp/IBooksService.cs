using LibraryApp.Shared;

namespace LibraryApp
{
    public interface IBooksService
    {
        Task Add(Books books);

        Task <Books> Get(Guid id);

        Task Update(Guid id,Books books);

        Task Delete(Guid id);

        Task<List<Books>> GetAll(); 

    }
}
