using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IUserLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<T>> RegisterUserAsync(UserInfo user);
        Task<Result<T>> LoginAsync(string email, string password, bool isGoogleLogin);
        Task<Result<List<T>>> GetAllByContactTypeAsync(long contactTypeId);
    }
}
