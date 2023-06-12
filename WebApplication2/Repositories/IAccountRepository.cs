using Microsoft.AspNetCore.Identity;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IAccountRepository 
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
