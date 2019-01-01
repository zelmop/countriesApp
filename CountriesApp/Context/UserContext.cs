using CountriesApp.Interfaces;
using CountriesApp.Models;
using CountriesApp.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CountriesApp.Context
{
    public class UserContext : IUserContext
    {
        private readonly IMongoDatabase _db;

        public UserContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}
