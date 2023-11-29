using TP3.Models;

namespace TP3.DAL.IRepositories
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int? id);
        void InsertMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(Movie movie);
        IEnumerable<Movie> AfficheSelonGenre(string name);
        IEnumerable<Movie> AfficheFilmsOrdonnes();
        void Save();
    }
}
