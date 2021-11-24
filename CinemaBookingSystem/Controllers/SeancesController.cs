﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaBookingSystem.Data;
using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Controllers
{
    public class SeancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seances.Include(s => s.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seances
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // GET: Seances/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        // POST: Seances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowingDate,Price,MovieId")] Seance seance)
        {
            var seats = _context.Seats.ToList();
            

            if (ModelState.IsValid)
            {
                _context.Add(seance);
                await _context.SaveChangesAsync();

                foreach (var seat in seats)
                {
                    var ticket = new Ticket
                    {
                        Price = seance.Price,
                        IsAvailable = true,
                        SeanceId = seance.Id,
                        SeatId = seat.Id
                    };
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                }

                
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", seance.MovieId);
            return View(seance);
        }

        // GET: Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seances.FindAsync(id);
            if (seance == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", seance.MovieId);
            return View(seance);
        }

        // POST: Seances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowingDate,Price,MovieId")] Seance seance)
        {
            if (id != seance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(seance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", seance.MovieId);
            return View(seance);
        }

        // GET: Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.Seances
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seance = await _context.Seances.FindAsync(id);
            _context.Seances.Remove(seance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeanceExists(int id)
        {
            return _context.Seances.Any(e => e.Id == id);
        }
    }
}
