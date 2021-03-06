using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

        
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte InStock { get; set; }
        public byte MoviesAvailable { get; set; }
    }
}