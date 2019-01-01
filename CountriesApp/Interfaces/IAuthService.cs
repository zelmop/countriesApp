using System.Threading.Tasks;

using CountriesApp.Models;

namespace CountriesApp.Interfaces
{
    public interface IAuthService
    {
        User Auhtenticate(string name, string password);
        User GetUser(string name);
    }
}
