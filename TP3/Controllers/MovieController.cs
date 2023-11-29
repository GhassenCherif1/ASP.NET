using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.DAL.IRepositories;
using TP3.Models;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(_movieRepository.GetMovies());
        }

        public IActionResult AfficheSelonGenre(string? name)
        {
            if (name == null)
                return RedirectToAction("Index");
            else
            {
                ViewData["name"] = name.ToUpper();

                return View(_movieRepository.AfficheSelonGenre(name));
            }
        }

        public IActionResult AfficheFilmsOrdonnes()
        {
            return View(_movieRepository.AfficheFilmsOrdonnes());
        }
        public IActionResult Create()
        {
            return(View());
        }
        [HttpPost]
        public IActionResult Create(Movie movie , IFormFile photoFile)
        {
            if (photoFile != null && photoFile.Length > 0)
            {
                // Generate a unique file name to prevent overwriting
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);

                // Define the path where the file will be saved
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // Copy the file to the specified path
                    photoFile.CopyTo(fileStream);
                }

                // Save the file path to the Movie model
                movie.Photo = "uploads/" + fileName;
            }
            _movieRepository.InsertMovie(movie);

            _movieRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var movie = _movieRepository.GetMovieById(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie , IFormFile photoFile)
        {
            if (photoFile != null && photoFile.Length > 0)
            {
                // Generate a unique file name to prevent overwriting
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);

                // Define the path where the file will be saved
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // Copy the file to the specified path
                    photoFile.CopyTo(fileStream);
                }

                // Save the file path to the Movie model (if needed)
                movie.Photo = "uploads/" + fileName; // Assuming you have a PhotoPath property in your Movie model
            }

            _movieRepository.UpdateMovie(movie);
            _movieRepository.Save();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int? id)
        {
            var movie=_movieRepository.GetMovieById(id);
            return View(movie);
        }
        public IActionResult Delete(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieRepository.DeleteMovie(movie.Id);
            _movieRepository.Save();
            return RedirectToAction("Index");
        }
    }
}