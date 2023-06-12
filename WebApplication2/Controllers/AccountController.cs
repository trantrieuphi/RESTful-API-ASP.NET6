using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountController(IAccountRepository repo)
        {
            _accountRepo = repo;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var result = await _accountRepo.SignUpAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            try
            {
                var token = await _accountRepo.SignInAsync(model);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(token);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
