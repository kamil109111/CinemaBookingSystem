using CinemaBookingSystem.Data;
using CinemaBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync(int? id)
        {
            List<Ticket> tickets = await _context.Tickets
                .Where(s => s.SeanceId == id)
                .Include(s => s.Seance.Movie.Genre)
                .Include(s => s.Seat)                
                .ToListAsync();

            ViewData["Title"] = tickets.FirstOrDefault().Seance.Movie.Title.ToString();
            ViewData["Genre"] = tickets.FirstOrDefault().Seance.Movie.Genre.Name.ToString();
            ViewData["RunningTime"] = tickets.FirstOrDefault().Seance.Movie.RunningTime.ToString();
            ViewData["Language"] = tickets.FirstOrDefault().Seance.Movie.OriginalLanguange.ToString();            

            return View(tickets);
        }
    }
}
