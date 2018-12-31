using CountriesApp.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountriesApp.Interfaces
{
    interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCoutries();
        Task<Country> GetCountry(string name);
        Task Create(Country country);
        Task<bool> Update(Country country);
        Task<bool> Delete(string name);
    }
}
