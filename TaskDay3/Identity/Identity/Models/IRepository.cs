using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Identity.Models {
    public interface IRepository : IDisposable {
        void Add<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        IList<T> List<T>() where T : class;
        T Find<T>(int id) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void SaveChanges();
    }

    public static class GenericRepositoryExtensions {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable, Expression<Func<T, TProperty>> relatedEntity) where T : class {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
        }
    }
}