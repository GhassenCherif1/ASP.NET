using TP3.Models;
namespace TP3.DAL.IRepositories
{
    public interface IGenreRepository : IDisposable
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(int? id);
        void InsertGenre(Genre genre);
        void DeleteGenre(int id);
        void UpdateGenre(Genre genre);
        void Save();
    }
}
