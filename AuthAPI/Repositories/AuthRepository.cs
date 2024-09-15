using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthAPI.Repositories.Services;
using AuthAPI.Models;
using AuthAPI.DTO;
using AuthAPI.AppConstants;

namespace AuthAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("isNewUser", user.IsNewUser.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Add role claims
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                // Generate token
                var token = new JwtSecurityTokenHandler().WriteToken(GetToken(authClaims));

                return new LoginResponseDTO
                {
                    StatusCode = StatusCodes.Success,
                    Message = StatusMessages.SuccessStatus,
                    Token = token
                };
            }
            return null;
        }

        public async Task<Response> RegisterAsync(RegisterDTO model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return new Response
                {
                    StatusCode = StatusCodes.BadRequest,
                    Message = StatusMessages.UserAlreadyExistsMessage
                };

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new Response
                {
                    StatusCode = StatusCodes.BadRequest,
                    Message = StatusMessages.UserCreationFailedMessage
                };

            // Ensure the Planner role exists
            if (!await _roleManager.RoleExistsAsync(UserRoles.Planner))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Planner));
            }

            // Assign Planner role
            await _userManager.AddToRoleAsync(user, UserRoles.Planner);

            return new Response
            {
                StatusCode = StatusCodes.Success,
                Message = StatusMessages.UserCreatedSuccessfullyMessage
            };
        }

        public async Task<Response> RegisterAdminAsync(RegisterDTO model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return new Response
                {
                    StatusCode = StatusCodes.BadRequest,
                    Message = StatusMessages.UserAlreadyExistsMessage
                };

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new Response
                {
                    StatusCode = StatusCodes.BadRequest,
                    Message = StatusMessages.UserCreationFailedMessage
                };

            // Ensure both Admin and Planner roles exist
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Planner))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Planner));
            }

            // Assign Admin role
            var adminRoleResult = await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            if (!adminRoleResult.Succeeded)
            {
                return new Response
                {
                    StatusCode = StatusCodes.NotFound,
                    Message = "Failed to assign Admin role"
                };
            }

            // Assign Planner role
            var plannerRoleResult = await _userManager.AddToRoleAsync(user, UserRoles.Planner);
            if (!plannerRoleResult.Succeeded)
            {
                return new Response
                {
                    StatusCode = StatusCodes.BadRequest,
                    Message = "Failed to assign Planner role"
                };
            }

            return new Response
            {
                StatusCode = StatusCodes.Success,
                Message = StatusMessages.UserCreatedSuccessfullyMessage
            };
        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public async Task<CompleteOnboardingResponseDTO> CompleteOnboardingAsync(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new CompleteOnboardingResponseDTO
                {
                    StatusCode = StatusCodes.NotFound,
                    Message = "User not found."
                };
            }

            user.IsNewUser = false;
            var result = await _userManager.UpdateAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("isNewUser", user.IsNewUser.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Add role claims
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                // Generate token
                var token = new JwtSecurityTokenHandler().WriteToken(GetToken(authClaims));


            if (!result.Succeeded)
            {
                return new CompleteOnboardingResponseDTO
                {
                    StatusCode = StatusCodes.BadRequest,
                    Message = "Failed to update user status."
                };
            }

            return new CompleteOnboardingResponseDTO
            {
                StatusCode = StatusCodes.Success,
                Message = "User onboarding completed successfully.",
                Token = token
            };


        }
    }
} 
