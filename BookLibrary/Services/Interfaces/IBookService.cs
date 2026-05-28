using BookLibrary.Models;

namespace BookLibrary.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync(int? genreId);
        Task<List<Genre>> GetGenresAsync();
        Task AddBookAsync(Book book, List<int> genreIds);
        Task DeleteBookAsync(int id);
    }
}
