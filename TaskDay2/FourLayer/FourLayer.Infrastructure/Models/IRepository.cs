using System;
using System.Linq;

namespace FourLayer.Infrastructure.Models {
    public interface IRepository : IDisposable {
        void Add<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        void SaveChanges();
        T Find<T>(int id) where T : class;
        IQueryable<T> Query<T>() where T : class;

    }
}