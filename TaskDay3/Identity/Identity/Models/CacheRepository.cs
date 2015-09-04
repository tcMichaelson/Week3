using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Identity.Models {
    public class CacheRepository : IRepository {

        private ApplicationDbContext _db;
        private IList<string> _cacheNames;

        public CacheRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<T> Query<T>() where T : class {
            return _db.Set<T>().AsQueryable();
        }

        public IList<T> List<T>() where T : class {
            var typeName = typeof(T).FullName;
            var cache = HttpRuntime.Cache[typeName] as IList<T>;

            if (cache == null) {
                cache = Query<T>().ToList();
                _cacheNames.Add(typeName);
                HttpRuntime.Cache[typeName] = cache;

            }
            return cache;
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

            foreach (string cache in _cacheNames) {
                HttpRuntime.Cache.Remove(cache);
            }

            _cacheNames.Clear();


        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}