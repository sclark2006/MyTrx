using MyTrx.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTrx.Data.Repositories
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> GetAll<T>(object options) where T : class, new();
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class, new();
        T GetById<T>(int id) where T : class, IEntity, new();
        T Create<T>(T entity) where T : class, new();
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class, new();
        void Delete<T>(int id) where T : class, IEntity, new();
        void Save();
    }
}
