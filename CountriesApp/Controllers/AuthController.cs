using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

using CountriesApp.Models;
using CountriesApp.Services;


namespace CountriesApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _authService.Auhtenticate(userParam.FirstName, userParam.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var user = await _userService.GetUser(name);

            if (user == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return new ObjectResult(user);
            }
        }

    }
}
