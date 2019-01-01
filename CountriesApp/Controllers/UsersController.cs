using CountriesApp.Models;
using CountriesApp.Services;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CountriesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _userService.GetAllUsers());
        }

        // GET: api/Users/name
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

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            var newUserDb = _userService.Create(user);

            if (newUserDb == null)
            {
                return StatusCode(500);
            }
            else
            {
                return StatusCode(201);
            }
        }

        // PUT: api/Users/x
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]User user)
        {
            var userFromDB = await _userService.GetUser(user.FirstName);

            if (userFromDB == null)
            {
                return new NotFoundResult();
            }
            else
            {
                user.Id = userFromDB.Id;

                await _userService.Update(user);

                return new OkObjectResult(user);
            }
        }

        // DELETE: api/Users/x
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var userFromDB = await _userService.GetUser(name);

            if (userFromDB == null)
            {
                return new NotFoundResult();
            }
            else
            {
                await _userService.Delete(name);

                return new OkResult();
            }
        }
    }
}
