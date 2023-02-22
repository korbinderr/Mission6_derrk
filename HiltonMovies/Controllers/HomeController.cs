﻿using HiltonMovies.Models;
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

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View(); 
        }

        [HttpPost]
        public IActionResult Movies(MovieResponse response)
        {
            _movieContext.Add(response);
            _movieContext.SaveChanges();

            return View("confirmation", response);
        }

        public IActionResult MoviesDisplay()
        {
            var movieList = _movieContext.Responses
            .Include(x => x.Category)
            //.Where(x => x.rating == "PG-13")
            .OrderBy(x => x.categoryID)
            .ToList();

            return View(movieList);
        }
    }
}
