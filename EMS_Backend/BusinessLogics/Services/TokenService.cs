using BusinessLogics.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilities.Constants;

namespace Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("TokenKey")));
        }

        public string GenerateToken(UserViewModel user)
        {
            // Adding User Details to the Token
            if (user.Email == null || user.UID == Guid.Empty || user.Role == null)
                throw new NullReferenceException(Constant.CustomExceptions.InvalidUser);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier,user.UID.ToString()),
            };

            // Creating Signature Algorithm
            var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            // Assembling Token
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credential,
                Expires = DateTime.UtcNow.AddMinutes(20)
            };

            // Generating the Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            string token = tokenHandler.WriteToken(myToken);
            return token;
        }
    }
}
