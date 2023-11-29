using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TP3.DAL.Interfaces;
using TP3.Models;
namespace TP3.Controllers
{
    public class GenreController : Controller
    {
        private IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            return View(_genreRepository.GetGenres());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if(genre == null)
            {
                return View();
            }
            else
            {
                _genreRepository.InsertGenre(genre);
                _genreRepository.Save();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var genre = _genreRepository.GetGenreById(id);
                if(genre == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(genre);
                }
            }
        }
        public IActionResult Edit(int? id)
        {
            var genre = _genreRepository.GetGenreById(id);
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,GenreName")] Genre genre)
        {
            ViewData["Model"] = ModelState.Values;
            if (ModelState.IsValid)
            {
                _genreRepository.UpdateGenre(genre);
                _genreRepository.Save();

                return RedirectToAction("Index");
                
            }
            else
            {
                return(View(genre));
            }
        }
    }
}
