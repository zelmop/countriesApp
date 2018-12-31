using CountriesApp.Interfaces;
using CountriesApp.Models;

using MongoDB.Driver;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryContext _context;

        public CountryService(ICountryContext context)
        {
            _context = context;
        }

        public async Task Create(Country country)
        {
            await _context.Countries.InsertOneAsync(country);
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Country> filter = Builders<Country>.Filter.Eq(x => x.Name, name);

            DeleteResult deleteResult = await _context.Countries.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Country>> GetAllCoutries()
        {
            return await _context.Countries.Find(x => true).ToListAsync();
        }

        public Task<Country> GetCountry(string name)
        {
            FilterDefinition<Country> filter = Builders<Country>.Filter.Eq(x => x.Name, name);

            return _context.Countries.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Country country)
        {
            ReplaceOneResult updateRsult = await _context.Countries
                .ReplaceOneAsync(
                    filter: x => x.Id == country.Id, replacement: country
                );

            return updateRsult.IsAcknowledged && updateRsult.ModifiedCount > 0;
        }
    }
}
