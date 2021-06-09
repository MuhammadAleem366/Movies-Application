using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCApp.Dtos;
using MVCApp.Models;
namespace MVCApp.Controllers.api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        
        
        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDto rentalDto)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CutomerId);
            
            /*if (customer == null)
            {
                return BadRequest("Invalid Customer Id");
            }*/

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            
            foreach (var movie in movies)
            {
                if (movie.MoviesAvailable == 0)
                {
                    return BadRequest("No movies are available");
                }
                movie.MoviesAvailable--;
                
                    var rental = new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };
                    _context.Rentals.Add(rental);

                _context.SaveChanges();

            }
            return Ok();
        }
    }
}
