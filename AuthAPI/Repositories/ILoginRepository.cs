using AuthAPI.Models;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public interface ILoginRepository
    {
        Task<Response> LoginAsync(LoginModel loginModel);
    }
}
