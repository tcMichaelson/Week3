using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Identity.Models {
    public class Repository : IRepository {

        private ApplicationDbContext _db;

        public Repository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<T> Query<T>() where T : class {
            return _db.Set<T>().AsQueryable();
        }

        public IList<T> List<T>() where T : class {
            return Query<T>().ToList();
        }

        public T Find<T>(int id) where T : class {

            return _db.Set<T>().Find(id);
        }

        public void Add<T>(T entity) where T : class {
            _db.Set<T>().Add(entity);
        }

        public void Delete<T>(int id) where T : class {
            _db.Set<T>().Remove(Find<T>(id));
        }

        public void SaveChanges() {

            _db.SaveChanges();
        }
        public void Dispose() {
            _db.Dispose();
        }
    }
}