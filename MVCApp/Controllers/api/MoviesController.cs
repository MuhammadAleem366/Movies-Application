using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCApp.Models;
namespace MVCApp.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Route GeT api/movies
        public IEnumerable<Movie> GetMovies() {
            var movies = _context.Movies.ToList();
            return movies;
        }

        //Route GET api/movies/id
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movie;
        }

        //Route POST api/movies
        [HttpPost]
        public Movie AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        //Route Put api/movies/id
        [HttpPut]
        public void UpdateMovie(int id, Movie movie) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieIndDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movieIndDb.Name = movie.Name;
            movieIndDb.GenreId = movie.GenreId;
            movieIndDb.InStock = movie.InStock;
            movieIndDb.ReleaseDate = movie.ReleaseDate;
            movieIndDb.DateAdded = movie.DateAdded;
            _context.SaveChanges();

        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
