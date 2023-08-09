using Domain.Authentication;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InfraData.Authentication
{
    public class TokenGenerator : ITokenGenarator
    {
        public dynamic Generator(Person person)
        {
            var claims = new List<Claim> {
            new Claim("Email", person.Email),
            new Claim("Name", person.Name),
            new Claim("Linkedin", person.Linkedin),
            new Claim("GitHub", person.GitHub),
            new Claim("Id", person.Id.ToString())
        };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vgçjdmsfklgnldsanfgknsdlnglksadngnasldngklasdn"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature),
            expires: expires,
            claims: claims
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                acess_token = token,
                expirations = expires
            };
        }

    }
}
