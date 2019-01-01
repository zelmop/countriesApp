using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using CountriesApp.Models;

namespace CountriesApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //private 

    }
}
