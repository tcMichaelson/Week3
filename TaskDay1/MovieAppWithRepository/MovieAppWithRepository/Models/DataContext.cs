using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieAppWithRepository.Models {
    public class DataContext : DbContext {
        public IDbSet<Actor> Actors { get; set; }
        public IDbSet<Movie> Movies { get; set; }

        internal void Add(Movie movie) {
            throw new NotImplementedException();
        }
    }
}