using System;
using System.Threading.Tasks;
using AuthAPI.Models;

namespace AuthAPI.Repositories.Services;

public interface IUserRepository
{
    Task<Response> GetUserDetailsAsync(string userId);
}
