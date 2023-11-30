using TP3.DAL.IRepositories;
using TP3.DAL.IServices;
using TP3.Models;

namespace TP3.DAL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return(_movieRepository.GetMovies());
        }
        public Movie GetMovieById(int? id)
        {
            return(_movieRepository.GetMovieById(id));
        }
        public void AddMovie(Movie movie)
        {
            _movieRepository.InsertMovie(movie);
            _movieRepository.Save();
        }
        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
            _movieRepository.Save();
        }
        public void DeleteMovie(Movie movie)
        {
            _movieRepository.DeleteMovie(movie);
            _movieRepository.Save();
        }
        public IEnumerable<Movie> AfficheSelonGenreNom(string name)
        {
            return _movieRepository.GetMoviesByGenreName(name);
        }
        public IEnumerable<Movie> AfficheFilmsOrdonnes()
        {
            return _movieRepository.GetMovies().OrderBy(m => m.Name).ToList();
        }
        public IEnumerable<Movie> AfficheSelonGenreId(int id)
        {
            return _movieRepository.GetMoviesByGenreId(id);
        }
    }
}
