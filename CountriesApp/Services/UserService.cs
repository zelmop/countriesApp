using CountriesApp.Interfaces;
using CountriesApp.Models;

using MongoDB.Driver;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserContext _context;

        public UserService(IUserContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.FirstName, name);

            DeleteResult deleteResult = await _context.Users.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Find(x => true).ToListAsync();
        }

        public Task<User> GetUser(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.FirstName, name);

            return _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(User user)
        {
            ReplaceOneResult updateRsult = await _context.Users
                .ReplaceOneAsync(
                    filter: x => x.Id == user.Id, replacement: user
                );

            return updateRsult.IsAcknowledged && updateRsult.ModifiedCount > 0;
        }

        public User GetUserSync(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.FirstName, name);

            return _context.Users.Find(filter).FirstOrDefault();
        }
    }
}
