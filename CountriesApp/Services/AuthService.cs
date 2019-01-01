using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

using CountriesApp.Interfaces;
using CountriesApp.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CountriesApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly Settings _settings;
        private readonly UserService _userService;

        public AuthService(IOptions<Settings> settings, UserService userService)
        {
            _settings = settings.Value;
            _userService = userService;
        }

        public User Auhtenticate(string name, string password)
        {
            var user = GetUser(name);
            var userId = user.Id;
            var userToken = user.Token;
            var userPassword = user.Password;

            if (user == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                userToken = tokenHandler.WriteToken(token);
                userPassword = null;

                return user;
            }
        }

        public User GetUser(string name)
        {
            var userDb = _userService.GetUserSync(name);

            if (userDb == null)
            {
                return null;
            }
            else
            {
                return userDb;
            }
        }

    }
}
