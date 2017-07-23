using MyTrx.Data.Contexts;
using MyTrx.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyTrx.Data.Repositories
{
    public class GenericRepository : IRepository
    {
        private readonly IDbContext _dbContext;

        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create<T>(T entity) where T : class, new()
        {
            T newEntity = _dbContext.Set<T>().Add(entity).Entity;
            return newEntity;
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : class, new()
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            _dbContext.Set<T>().Remove(entity);
        }

        public void Delete<T>(int id) where T : class, IEntity, new()
        {
            var entity = GetById<T>(id);
            Delete<T>(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            var query = _dbContext.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll<T>(object options) where T : class, new()
        {
            var query = _dbContext.Set<T>();
            return query;
        }

        public T GetById<T>(int id) where T : class, IEntity, new()
        {
            T entity = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
            return entity;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
