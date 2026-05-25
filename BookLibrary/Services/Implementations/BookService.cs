using BookLibrary.Models;
using BookLibrary.Repositories.Interfaces;
using BookLibrary.Services.Interfaces;

namespace BookLibrary.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetBooksAsync(Genre? genre)
        {
            if (genre.HasValue)
                return await _repository.GetByGenreAsync(genre.Value);

            return await _repository.GetAllAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            await _repository.AddAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}