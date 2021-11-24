using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Price { get; set; }

        public int SeanceId { get; set; }
        public Seance Seance { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
