using System.IdentityModel.Tokens.Jwt;
using ConductOfCode.Extensions;
using ConductOfCode.Models;
using ConductOfCode.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConductOfCode.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private TokenOptions Options { get; }

        public AuthenticationController(IOptions<TokenOptions> options)
        {
            Options = options.Value;
        }

        [HttpPost("[action]")]
        public TokenResponse Token([FromBody]TokenRequest request)
        {
            // TODO: Authenticate request

            var token = new JwtSecurityToken(
                audience: Options.Audience,
                issuer: Options.Issuer,
                expires: Options.GetExpiration(),
                signingCredentials: Options.GetSigningCredentials());

            return new TokenResponse
            {
                token_type = Options.Type,
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = (int)Options.ValidFor.TotalSeconds
            };
        }
    }
}