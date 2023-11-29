using TP3.DAL.Interfaces;
using TP3.Models;

namespace TP3.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly TP3Context context;
        private bool disposed = false;
        public GenreRepository(TP3Context context) {
            this.context = context;
        }
        public IEnumerable<Genre> GetGenres() {
            return context.Genres.ToList();
        }
        public Genre GetGenreById(int? id)
        {
            return context.Genres.FirstOrDefault(m => m.Id == id);
        }
        public void InsertGenre(Genre genre)
        {
            context.Genres.Add(genre);
        }
        public void DeleteGenre(int id)
        {
            var genre = context.Genres.FirstOrDefault(p => p.Id == id);
            context.Genres.Remove(genre);
        }
        public void UpdateGenre(Genre genre)
        {
            context.Genres.Update(genre);
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
