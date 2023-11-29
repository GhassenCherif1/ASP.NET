using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly TP3Context _context;

        public MovieController(TP3Context context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            var tP3Context = _context.Movies.Include(m => m.Genre);
            return View(await tP3Context.ToListAsync());
        }

        public async Task<IActionResult> AfficheSelonGenre(string? name)
        {
            if (name == null)
                return RedirectToAction("Index");
            else
            {
                ViewData["name"] = name.ToUpper();
                // Query to retrieve movies with related Genre based on the specified genre name
                var tP3Context = from t in _context.Movies.Include(t => t.Genre)
                                 where t.Genre.GenreName == name
                                 select t;

                // Execute the query and convert the result to a list asynchronously
                var movies = await tP3Context.ToListAsync();

                // Return the list of movies as a view
                return View(movies);
            }
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

                // Save the file path to the Movie model (if needed)
                movie.Photo = "uploads/"+fileName; // Assuming you have a PhotoPath property in your Movie model
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
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
            
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int? id)
        {
            var movie=_context.Movies.Include(t => t.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
    }
}