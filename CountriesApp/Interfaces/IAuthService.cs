using System.Threading.Tasks;

using CountriesApp.Models;

namespace CountriesApp.Interfaces
{
    interface IAuthService
    {
        User Authenticate(string username, string password);
    }
}
