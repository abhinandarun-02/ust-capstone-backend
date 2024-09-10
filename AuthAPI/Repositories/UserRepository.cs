using System;
using System.Threading.Tasks;
using AuthAPI.AppConstants;
using AuthAPI.DTO;
using AuthAPI.Models;
using AuthAPI.Repositories.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AuthAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<Response> GetUserDetailsAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            return new Response { StatusCode = StatusCodes.NotFound, Message = "User not found" };
        }

         var roles = await _userManager.GetRolesAsync(user);

        // Assuming you have a UserDetailDTO to return user details
        var userDetails = new UserDetailsDTO
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            Roles = roles
        };

        return new Response { StatusCode = StatusCodes.Success, Data = userDetails };
    }
}
