using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.DAL.IRepositories;
using TP3.DAL.IServices;
using TP3.Models;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(_movieService.GetMovies());
        }

        public IActionResult AfficheSelonGenreNom(string? name)
        {
            if (name == null)
                return RedirectToAction("Index");
            else
            {
                ViewData["name"] = name.ToUpper();

                return View(_movieService.AfficheSelonGenreNom(name));
            }
        }

        public IActionResult AfficheFilmsOrdonnes()
        {
            return View(_movieService.AfficheFilmsOrdonnes());
        }
        public IActionResult AfficheSelonGenreId(int id)
        {
            ViewData["id"] = id;
            return View(_movieService.AfficheSelonGenreId(id));
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
            _movieService.AddMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var movie = _movieService.GetMovieById(id);
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

            _movieService.UpdateMovie(movie);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int? id)
        {
            var movie=_movieService.GetMovieById(id);
            return View(movie);
        }
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieService.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
    }
}