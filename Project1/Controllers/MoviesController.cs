using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class MoviesController : Controller
    {

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            //Exmaple RedirectToAction
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            // ViewData["Movie"] = movie;
            // ViewBag.Movie = movie;
            
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(sortBy);
        //}

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + " " + month);
            
        //}

    }
}