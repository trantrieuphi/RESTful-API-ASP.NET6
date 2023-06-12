using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBookAsync();
        public Task<BookModel> GetBookByIdAsync(int id);
        public Task<int> AddBookAsync(BookModel book);
        public Task UpdateBookAsync(int id, BookModel book);
        public Task DeleteBookAsync(int id);
    }
}
