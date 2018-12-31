using CountriesApp.Interfaces;
using CountriesApp.Models;
using CountriesApp.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CountriesApp.Context
{
    public class CountryContext : ICountryContext
    {
        private readonly IMongoDatabase _db;

        public CountryContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Country> Countries => _db.GetCollection<Country>("Countries");
    }
}
