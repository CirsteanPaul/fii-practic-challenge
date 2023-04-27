using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace hackatonBackend.ProjectData.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Any(Expression<Func<TEntity, bool>> where);
        int Count();
        int Count(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        TEntity Find(string id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int rowCount);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
