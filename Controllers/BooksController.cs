using LastLastChance.Data.Services;
using LastLastChance.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LastLastChance.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync();
            return View(allBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allBooks.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }

        //GET: Books/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBookByIdAsync(id);
            return View(bookDetail);
        }

        //GET: Books/Create
        public async Task<IActionResult> Create()
        {
            //var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            //ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            //ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM movie)
        {
            if (!ModelState.IsValid)
            {
                //var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                //ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                //ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewBookAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Book/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetBookByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageUrl,
                BookCategory = movieDetails.BookCategory,
            };

            //var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            //ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            //ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                //var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                //ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                //ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateBookAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
