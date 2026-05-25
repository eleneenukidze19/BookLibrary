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

        public async Task<IActionResult> Index(Genre? genre)
        {
            ViewBag.SelectedGenre = genre;
            ViewBag.Genres = Enum.GetValues(typeof(Genre));

            var books = await _bookService.GetBooksAsync(genre);
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Genres = Enum.GetValues(typeof(Genre));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = Enum.GetValues(typeof(Genre));
                return View(book);
            }

            await _bookService.AddBookAsync(book);
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