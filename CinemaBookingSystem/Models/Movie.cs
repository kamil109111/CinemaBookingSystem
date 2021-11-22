using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string RunningTime { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Production { get; set; }
        public string OriginalLanguange { get; set; }
        public string AgeRestriction { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
