using BookLibrary.Models;

namespace BookLibrary.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync(Genre? genre);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}