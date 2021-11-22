using CinemaBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data
{
    public class SeatSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public SeatSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Seats.Any())
                {
                    var seats = GetSeats();
                    _dbContext.Seats.AddRange(seats);
                    _dbContext.SaveChanges();
                }
            }
        }

        private static IEnumerable<Seat> GetSeats()
        {
            var seats = new List<Seat>() { };          
               
            for (int i = 0; i < 40; i++)
            {
                var seat = new Seat { IsAvailable = true };
                seats.Add(seat);
            }

            return seats;
        }
    }
}
