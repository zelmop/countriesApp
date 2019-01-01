using CountriesApp.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountriesApp.Interfaces
{
    interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string name);
        Task Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(string name);
        User GetUserSync(string name);
    }
}
