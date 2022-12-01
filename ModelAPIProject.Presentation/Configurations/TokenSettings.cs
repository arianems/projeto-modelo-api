using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace ModelAPIProject.Presentation.Configurations
{
    public class TokenSettings
    {
        private readonly string SecretKey;
        /// <summary>
        /// Responsible for generating the tokens used by the API.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A serialized JwtSecurity Token</returns>
        public string GenerateToken(string email)
        {
            throw new NotImplementedException();

            /*
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = GetKey();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
            */
        }

        public static byte[] GetKey()
        {
            throw new NotImplementedException();

            /*
            var configuration = new ConfigurationBuilder();
            var settings = configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var tokenSettings = settings.Build().GetSection("SecretKey")
                .Get<TokenSettings>();

            var key = Encoding.UTF8.GetBytes(tokenSettings.SecretKey);
            return key;
            */
        }
    }
}
