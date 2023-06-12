using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class BookStoreContext: IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
        {
        }
        public DbSet<Book>? Books { get; set; }
    }
}
