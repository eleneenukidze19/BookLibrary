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

        public async Task<List<Book>> GetBooksAsync(int? genreId)
        {
            if (genreId.HasValue)
                return await _repository.GetByGenreAsync(genreId.Value);

            return await _repository.GetAllAsync();
        }

        public Task<List<Genre>> GetGenresAsync()
        {
            return _repository.GetGenresAsync();
        }

        public async Task AddBookAsync(Book book, List<int> genreIds)
        {
            book.BookGenres = genreIds
                .Select(id => new BookGenre { GenreId = id })
                .ToList();

            await _repository.AddAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}