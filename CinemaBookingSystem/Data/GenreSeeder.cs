using CinemaBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data
{
    public class GenreSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Genres.Any())
                {
                    var genres = GetGenres();
                    _dbContext.Genres.AddRange(genres);
                    _dbContext.SaveChanges();
                }
            }
        }

        private static IEnumerable<Genre> GetGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "Action" 
                },

                new Genre()
                {
                    Name = "Comedy"
                },

                new Genre()
                {
                    Name = "Drama"
                },

                new Genre()
                {
                    Name = "Fantasy"
                },

                new Genre()
                {
                    Name = "Horror"
                },

                new Genre()
                {
                    Name = "Mystery"
                },

                new Genre()
                {
                    Name = "Romance"
                },

                new Genre()
                {
                    Name = "Thriller"
                },

                new Genre()
                {
                    Name = "Western"
                },
            };

            return genres;
        }
    }
}
