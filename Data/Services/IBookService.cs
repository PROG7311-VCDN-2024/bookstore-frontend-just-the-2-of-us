using LastLastChance.Data.Base;
using LastLastChance.Data.ViewModels;
using LastLastChance.Models;

namespace LastLastChance.Data.Services
{
    public interface IBookService:IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
        //Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}
