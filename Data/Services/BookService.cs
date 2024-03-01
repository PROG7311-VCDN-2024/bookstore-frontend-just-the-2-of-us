using LastLastChance.Data.Base;
using LastLastChance.Data.ViewModels;
using LastLastChance.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LastLastChance.Data.Services
{
    public class BookService : EntityBaseRepository<Book>, IBookService
    {
        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                BookCategory = data.BookCategory,
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }

        //public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        //{
        //    var response = new NewBookDropdownsVM()
        //    {
        //        Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
        //        Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
        //        Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
        //    };

        //    return response;
        //}

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
                dbBook.Name = data.Name;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageUrl = data.ImageURL;
                dbBook.StartDate = data.StartDate;
                dbBook.EndDate = data.EndDate;
                dbBook.BookCategory = data.BookCategory;
                await _context.SaveChangesAsync();
            }

            ////Remove existing actors
            //var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            //_context.Actors_Movies.RemoveRange(existingActorsDb);
            //await _context.SaveChangesAsync();

            //Add Movie Actors
            //foreach (var actorId in data.ActorIds)
            //{
            //    var newActorMovie = new Actor_Movie()
            //    {
            //        MovieId = data.Id,
            //        ActorId = actorId
            //    };
            //    await _context.Actors_Movies.AddAsync(newActorMovie);
            //}
            //await _context.SaveChangesAsync();
        }
    }
}
