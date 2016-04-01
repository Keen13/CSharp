using SearchMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchMovies.Controllers
{
    public class HomeController : Controller
    {
        MoviesContext db = new MoviesContext();

        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

    }
}