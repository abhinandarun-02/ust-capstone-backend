using AuthAPI.Models;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public interface IRegisterAdminRepository
    {
        Task<Response> RegisterAdminAsync(Admin admin);
    }
}
