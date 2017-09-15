using MyTrx.Data.Contexts;
using MyTrx.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyTrx.Data.Repositories
{
    public class GenericRepository : IRepository
    {
        private readonly IMyTrxContext _dbContext;

        public GenericRepository(IMyTrxContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create<T>(T entity) where T : class
        {
            T newEntity = _dbContext.Set<T>().Add(entity).Entity;
            return newEntity;
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : class
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            _dbContext.Set<T>().Remove(entity);
        }

        public void Delete<T>(int id) where T : class, IEntity
        {
            var entity = GetById<T>(id);
            Delete<T>(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var query = _dbContext.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll<T>(params string[] propertiesToInclude) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if(propertiesToInclude.Length > 0)
            {
                foreach (var prop in propertiesToInclude)
                {
                    query = query.Include(prop);
                }                
            }
                
            return query;
        }

        public T GetById<T>(int id) where T : class, IEntity
        {
            T entity = _dbContext.Find<T>(id);
            return entity;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
