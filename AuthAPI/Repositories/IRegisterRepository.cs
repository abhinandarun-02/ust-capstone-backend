using AuthAPI.Models;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public interface IRegisterRepository
    {
        Task<Response> RegisterPlannerAsync(Planner planner);
    }
}
