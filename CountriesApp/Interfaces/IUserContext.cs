using CountriesApp.Models;
using MongoDB.Driver;

namespace CountriesApp.Interfaces
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
