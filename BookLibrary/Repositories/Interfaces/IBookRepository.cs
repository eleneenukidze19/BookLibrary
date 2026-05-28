using BookLibrary.Models;

namespace BookLibrary.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> GetByGenreAsync(int genreId);
        Task<List<Genre>> GetGenresAsync();
        Task AddAsync(Book book);
        Task DeleteAsync(int id);
    }
}
