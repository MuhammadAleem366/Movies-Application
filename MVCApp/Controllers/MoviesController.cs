using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;
using MVCApp.ViewModels;
namespace MVCApp.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;
        //Constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View();
            }
            return View("ReadOnlyForUser");
        }



        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }


        //Get /Movies/MovieForm
        //Authorize will be used to restrict that no one other than Admin can Use Edit Option
        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult MovieForm(int? id)
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            if (!(id == null))
            {
                {
                    var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
                    viewModel.Movie = movie;
                   
                }

            }
            
            return View(viewModel);
    }

        //We specify here HHTpPost because it is the action for form that is subnmitted
        [HttpPost]
       public ActionResult Save(Movie movie)
        {
            
                if (movie.Id == 0)
                {
                    //if id is equal then movie will be added
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                }
                else
                {
                    //if id not equal then it means its updated
                    var movieInDb = _context.Movies.Include(m => m.Genre).Single(m => m.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.DateAdded = movie.DateAdded;
                    movieInDb.InStock = movie.InStock;
                    movieInDb.GenreId = movie.GenreId;
                    _context.SaveChanges();
                }
            
            
            return RedirectToAction("Index","Movies");
        }
    }
}