using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Seance
    {
        public int Id { get; set; }
        public DateTime ShowingDate { get; set; }
        public decimal Price { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual List<Seance_Seat> Seance_Seats { get; set; }
    }
}
