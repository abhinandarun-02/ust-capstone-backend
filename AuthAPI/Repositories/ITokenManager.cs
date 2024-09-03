using AuthAPI.Models;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public interface ITokenManager
    {
        Task<string> Authenticate(LoginModel loginModel);
    }
}
