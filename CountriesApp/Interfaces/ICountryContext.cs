using CountriesApp.Models;
using MongoDB.Driver;

namespace CountriesApp.Interfaces
{
    public interface ICountryContext
    {
       IMongoCollection<Country> Countries { get; }
    }
}
