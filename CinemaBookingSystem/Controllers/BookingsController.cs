using CinemaBookingSystem.Data;
using CinemaBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public async Task<IActionResult> Index(int? id)
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
            ViewData["DateTime"] = tickets.FirstOrDefault().Seance.ShowingDate.ToString("dd/MM/yyyy HH:mm");

            return View(tickets);
        }

        public ActionResult HandleButtonClick(string id)
        {
            int ticketId = Int32.Parse(id);
            var ticket = _context.Tickets
                .Where(t => t.Id == ticketId).SingleOrDefault();

            ticket.IsAvailable = !ticket.IsAvailable;
            _context.Update(ticket);
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = ticket.SeanceId });
        }

        [HttpPost]
        public async Task<IActionResult> BookNow([FromBody]List<JsonTicket> listOfTickets)
        {
            List<Ticket> bookedTickets = new();            

            foreach(var ticket in listOfTickets )
            {
                var selectedTicket = await _context.Tickets.Where(t => t.Id == ticket.Id).FirstOrDefaultAsync();
                bookedTickets.Add(selectedTicket);
            }
            
            return View(bookedTickets);
        }
       
    }
}
