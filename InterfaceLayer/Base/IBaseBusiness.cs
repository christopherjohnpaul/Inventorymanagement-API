using ModelLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Base
{
    public interface IBaseBusiness<T> where T : class
    {
        Task<Result<T>> CreateAsync(T entity);
        Task<Result<T>> FindAsync(long id);
        Task<Result<List<T>>> FindAllAsync();
        Task<Result<T>> UpdateAsync(T entity, long id);
        Task<Result<T>> DeleteAsync(long id);
    }
}
