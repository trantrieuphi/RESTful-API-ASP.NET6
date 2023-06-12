using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;   
    }
}
