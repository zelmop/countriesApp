using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using MongoDB.Driver;

using CountriesApp.Interfaces;
using CountriesApp.Models;

namespace CountriesApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly Settings _settings;

        public AuthService(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
