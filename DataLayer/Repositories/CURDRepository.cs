using DataLayer.DBContext;
using InterfaceLayer.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CURDRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly OptionsBuild options = new OptionsBuild();
        public CURDRepository()
        {
            options = new OptionsBuild();
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                await context.AddAsync<T>(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                T objFound = await context.FindAsync<T>(id);
                if (objFound != null)
                {
                    context.Remove<T>(objFound);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public virtual async Task<IList<T>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.Set<T>().ToListAsync();
                return result;
            }
        }

        public virtual async Task<T> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.FindAsync<T>(id);
                return obj;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity, long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.FindAsync<T>(id);
                context.Entry<T>(obj).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public IQueryable<T> GetAll()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return context.Set<T>();
            }
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public virtual T Get(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return context.Set<T>().Find(id);
            }
        }

        public virtual async Task<T> GetAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public virtual T Add(T t)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                context.Set<T>().Add(t);
                context.SaveChanges();
                return t;
            }
        }

        public virtual async Task<T> AddAsyn(T t)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                context.Set<T>().Add(t);
                await context.SaveChangesAsync();
                return t;
            }
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return context.Set<T>().SingleOrDefault(match);
            }
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.Set<T>().SingleOrDefaultAsync(match);
            }
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return context.Set<T>().Where(match).ToList();
            }
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.Set<T>().Where(match).ToListAsync();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual async Task<long> DeleteAsyn(T entity)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync();
            }
        }

        public virtual T Update(T t, object key)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                if (t == null)
                    return null;
                T exist = context.Set<T>().Find(key);
                if (exist != null)
                {
                    context.Entry(exist).CurrentValues.SetValues(t);
                    context.SaveChanges();
                }
                return exist;
            }
        }

        public virtual async Task<T> UpdateAsyn(T t, object key)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                if (t == null)
                    return null;
                T exist = await context.Set<T>().FindAsync(key);
                if (exist != null)
                {
                    context.Entry(exist).CurrentValues.SetValues(t);
                    await context.SaveChangesAsync();
                }
                return exist;
            }
        }

        public long Count()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return context.Set<T>().Count();
            }
        }

        public async Task<int> CountAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.Set<T>().CountAsync();
            }
        }

        public virtual void Save()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {

                context.SaveChanges();
            }
        }

        public async virtual Task<long> SaveAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.SaveChangesAsync();
            }
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                IQueryable<T> query = context.Set<T>().Where(predicate);
                return query;
            }
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                return await context.Set<T>().Where(predicate).ToListAsync();
            }
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                    this.disposed = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
