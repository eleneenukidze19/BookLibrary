using BookLibrary.Models;
using BookLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(int? genreId)
        {
            ViewBag.SelectedGenreId = genreId;
            ViewBag.Genres = await _bookService.GetGenresAsync();

            var books = await _bookService.GetBooksAsync(genreId);
            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new BookCreateViewModel
            {
                AllGenres = await _bookService.GetGenresAsync()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AllGenres = await _bookService.GetGenresAsync();
                return View(vm);
            }

            var book = new Book
            {
                Title = vm.Title,
                Author = vm.Author,
                Year = vm.Year
            };

            await _bookService.AddBookAsync(book, vm.SelectedGenreIds);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}