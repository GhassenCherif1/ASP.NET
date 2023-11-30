using TP3.Models;

namespace TP3.DAL.IRepositories
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int? id);
        void InsertMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
        IEnumerable<Movie> GetMoviesByGenreName(string name);
        IEnumerable<Movie> GetMoviesByGenreId(int id);
        void Save();
    }
}
