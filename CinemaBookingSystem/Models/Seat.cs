using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }

        public virtual List<Seance_Seat> Seance_Seats { get; set; }
    }
}
