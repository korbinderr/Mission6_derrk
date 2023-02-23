using HiltonMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieDataContext _movieContext { get; set; }

        // Constructor
        public HomeController(MovieDataContext movies)
        {
            _movieContext = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        // Get and Post for the Movies action, that will either show the add-movie form, or add the new movie when submitted
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View(); 
        }

        [HttpPost]
        public IActionResult Movies(MovieResponse response)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(response);
                _movieContext.SaveChanges();           
                
                return View("confirmation", response);

            }

            else //if invalid
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(response);
            }

        }

        // Display all of the existing movies in the db
        public IActionResult MoviesDisplay()
        {
            var movieList = _movieContext.Responses
            .Include(x => x.Category)
            //.Where(x => x.rating == "PG-13")
            .OrderBy(x => x.categoryID)
            .ToList();

            return View(movieList);
        }

        //The Get and Post for the EDIT functionality; show the form with the selected movie's data, then update the db with changes when posted
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movie1 = _movieContext.Responses.Single(x=> x.MovieID == id);

            return View("Movies", movie1);
        }

        [HttpPost]
        public IActionResult Edit (int id, MovieResponse updatedMovie)
        {
            updatedMovie.MovieID = id;

            _movieContext.Update(updatedMovie);
            _movieContext.SaveChanges();

            return RedirectToAction("MoviesDisplay");
        }

        //The Get and Post for the DELETE functionality; get an .cshtml page that asks for confirmation, then delete when posted and return to the movie list
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieDel = _movieContext.Responses.Single(x => x.MovieID == id);
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View(movieDel);
        }       
        
        [HttpPost]
        public IActionResult Delete (MovieResponse mr)
        {
            _movieContext.Responses.Remove(mr);
            _movieContext.SaveChanges();
            return RedirectToAction("MoviesDisplay");
        }

    }
}
