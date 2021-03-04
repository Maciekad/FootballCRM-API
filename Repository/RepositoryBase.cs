using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await RepositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            await RepositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            RepositoryContext.Entry(entity).State = EntityState.Modified;
            await RepositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await RepositoryContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();

            return entity;
        }
    }
}
