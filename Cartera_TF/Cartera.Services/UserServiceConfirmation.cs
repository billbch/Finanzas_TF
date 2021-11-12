using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;



using Cartera.DataAccess;
//using Cartera.Services.Settings;
using Cartera.Entities;
using Microsoft.Extensions.Configuration;

namespace Cartera.Services
{
    public class UserServiceConfirmation : IUserServiceConfirmation
    {
        private IAccountRepository _accountRepository;
        // TODO: Replace by Persistence Implementation


        // Secret Settings
        private readonly AppSettings _appSettings;
        private readonly IConfiguration Configuration;


       public UserServiceConfirmation(IOptions<AppSettings> appSettings, IAccountRepository accountRepository, IConfiguration configuration)
      {

           _appSettings = appSettings.Value;
          _accountRepository = accountRepository;
            Configuration = configuration;
            
            
      }

        public AuthenticateResponse Authenticate(AuthenticateRequest body)
        {
            try
            {
                var user = _accountRepository.GetByUserandPasswordIdAsync(body.Username, body.Password);
                //Return null when user not found
                if (user.Result == null)
                {
                    return null;
                }
            var token = generateJwtToken(user.Result);
            return new AuthenticateResponse(user.Result, token);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string generateJwtToken(Account user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var miconf = Configuration["Secret"];
            var key = Encoding.ASCII.GetBytes(Configuration["Secret"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
