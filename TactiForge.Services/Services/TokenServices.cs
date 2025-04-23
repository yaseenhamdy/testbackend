using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;  // Add this for SymmetricSecurityKey and JwtSecurityToken
using TactiForge.Core.Identity;
using TactiForge.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using TactiForge.API.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace TactiForge.Services.Services
{
    public class TokenServices : ITokenService
    {
        private readonly JwtOptions _options;
        private readonly UserManager<AppUser> _userManager;

        public TokenServices(IOptions<JwtOptions> options, UserManager<AppUser> userManager)
        {
            _options = options.Value;
            _userManager = userManager;
        }

        public async Task<string> CreateTokenAsync(AppUser user, int teamId, int coachId)
        {
            // 1. Private Claims
            var authClaims = new List<Claim>
    {
        new Claim("Name", user.DisplayName),
        new Claim("Email", user.Email!),
        new Claim("TeamId", teamId.ToString()),  
        new Claim("CoachId", coachId.ToString()), 
        new Claim("EmailConfirmed", user.EmailConfirmed.ToString()), 

    };

            // Add roles to the claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            // 2. Key
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            // 3. Create the token
            var token = new JwtSecurityToken(
                issuer: _options.ValidIssuer,
                audience: _options.ValidAudience,
                expires: DateTime.Now.AddDays(double.Parse(_options.DurationInDays)),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
