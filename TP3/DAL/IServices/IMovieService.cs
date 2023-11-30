using TP3.Models;

namespace TP3.DAL.IServices
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int? id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        IEnumerable<Movie> AfficheSelonGenreNom(string name);
        IEnumerable<Movie> AfficheFilmsOrdonnes();
        IEnumerable<Movie> AfficheSelonGenreId(int id);

    }
}
