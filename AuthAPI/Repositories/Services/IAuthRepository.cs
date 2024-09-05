using AuthAPI.DTO;
using AuthAPI.Models;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace AuthAPI.Repositories.Services
{
    public interface IAuthRepository
    {
        Task<Response> RegisterAsync(RegisterDTO registerModel);
        Task<Response> RegisterAdminAsync(RegisterDTO registerModel);
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginModel);

    }
}
