using Microsoft.EntityFrameworkCore;
using TP3.DAL.IRepositories;
using TP3.Models;

namespace TP3.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly TP3Context context;
        private bool disposed = false;
        public MovieRepository(TP3Context context)
        {
            this.context = context;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return(context.Movies.Include(m => m.Genre).ToList());
        }
        public Movie GetMovieById(int? id)
        {
            return context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
        }
        public void InsertMovie(Movie movie)
        {
            context.Movies.Add(movie);
        }
        public void DeleteMovie(int id)
        {
            Movie movie = context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id==id);
            context.Movies.Remove(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            context.Movies.Update(movie);
        }
        public IEnumerable<Movie> AfficheSelonGenre(string name)
        {
            var movies = from c in context.Movies.Include(t => t.Genre)
                        where c.Genre.GenreName == name
                        select c;
            return movies.ToList();
        }
        public IEnumerable<Movie> AfficheFilmsOrdonnes()
        {
            return GetMovies().OrderBy(m => m.Name).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
