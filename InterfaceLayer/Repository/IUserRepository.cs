using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        Task<T> LoginAsync(string email, string password, bool isGoogleLogin);
        Task<T> RegisterUserAsync(T user);
        Task<IList<T>> GetAllByContactTypeAsync(long contactTypeId);
    }
}
