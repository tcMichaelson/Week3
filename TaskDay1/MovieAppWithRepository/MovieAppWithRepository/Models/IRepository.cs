using System.Collections.Generic;

namespace MovieAppWithRepository.Models {
    public interface IRepository {
        void CreateMovie(Movie movie);
        void DeleteMovie(int id);
        Movie GetMovieById(int id);
        IList<Movie> ListMovies();
        void UpdateMovie(Movie movie);
    }
}