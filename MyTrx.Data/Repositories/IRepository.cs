using Microsoft.EntityFrameworkCore;
using MyTrx.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyTrx.Data.Repositories
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> GetAll<T>(params string[] propertiesToInclude) where T : class;
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        T GetById<T>(int id) where T : class, IEntity;
        T Create<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class, IEntity;
        void Save();
    }

    public class QueryOptions {
        public string Where { get; set; }
        public int Max { get; set; }
        public string Include { get; set; }
    }
}
