using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FullCart.Application.Interfaces;
using FullCart.Domain.Entities.Identities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FullCart.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key; 

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]!));
        }
        public string CreateToken(AppUser user)
        {
           var claims = new List<Claim>
           {
             new Claim(JwtRegisteredClaimNames.Email,user.Email!),
             new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
           };

           var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);  

           var tokenDescriptor = new SecurityTokenDescriptor
           {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials,
            Issuer = _configuration["Token:Issuer"]
           };

           var tokenHandler = new JwtSecurityTokenHandler();

           var token = tokenHandler.CreateToken(tokenDescriptor);

           return tokenHandler.WriteToken(token);
        }
    }
}