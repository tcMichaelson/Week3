using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAppWithRepository.Models {
    public class Repository : IRepository {

        private DataContext _db;

        public Repository(DataContext db) {
            _db = db;
        }

        public IList<Movie> ListMovies() {
            return (from m in _db.Movies select m).ToList();
        }

        public void CreateMovie(Movie movie) {
            _db.Add(movie);
            _db.SaveChanges();
        }

        public Movie GetMovieById(int id) {
            return (from m in _db.Movies where m.Id == id select m).FirstOrDefault();
        }

        public void UpdateMovie(Movie movie) {
            var newMovie = GetMovieById(movie.Id);
            newMovie.Name = movie.Name;
            newMovie.ReleaseDate = movie.ReleaseDate;
            newMovie.Director = movie.Director;
            _db.SaveChanges();
        }

        public void DeleteMovie(int id) {
            var movie = GetMovieById(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            
        }
    }
}