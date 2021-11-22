using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Seance_Seat
    {
        public int Id { get; set; }

        public int SeanceId { get; set; }
        public Seance Seance { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
