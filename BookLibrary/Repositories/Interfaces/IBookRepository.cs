using BookLibrary.Models;

namespace BookLibrary.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> GetByGenreAsync(Genre genre);
        Task AddAsync(Book book);
        Task DeleteAsync(int id);
    }
}