using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public class TokenManager : ITokenManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public TokenManager(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(LoginModel loginModel)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a=>a.Username == loginModel.Username && a.Password == loginModel.Password);
            var planner = await _context.Planners
                .FirstOrDefaultAsync(p => p.Username == loginModel.Username && p.Password == loginModel.Password);

            if (admin == null && planner == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var user = admin ?? (object)planner;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username),
                new Claim(ClaimTypes.Role, admin != null ? "Admin" : "Planner"),
                new Claim("UserId", (admin?.Id ?? planner?.Id).ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
