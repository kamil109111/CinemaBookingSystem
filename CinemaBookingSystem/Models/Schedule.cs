using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Schedule
    { 
        public virtual List<Seance> Seances { get; set; }
    }
}
