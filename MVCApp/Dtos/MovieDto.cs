using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCApp.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public GenresDto Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }


        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte InStock { get; set; }
    }
}