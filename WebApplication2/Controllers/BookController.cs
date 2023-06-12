using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                var books = await _bookRepo.GetAllBookAsync();
                return Ok(books);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookRepo.GetBookByIdAsync(id);
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(book);
                return CreatedAtAction(nameof(GetBookById), new { id = newBookId }, book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, BookModel book)
        {
            if(id != book.Id)
            {
                return NotFound();
            }
            try
            {
                await _bookRepo.UpdateBookAsync(id, book);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var bookToDelete = await _bookRepo.GetBookByIdAsync(id);
                if(bookToDelete == null)
                {
                    return NotFound();
                }
                await _bookRepo.DeleteBookAsync(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }   
    }
}
