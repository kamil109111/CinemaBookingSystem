﻿using CinemaBookingSystem.Data;
using CinemaBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync(string date)
        {
            List<Seance> seances = new List<Seance>();



            if (!string.IsNullOrEmpty(date))
            {
                seances = await _context.Seances
                    .Where(d => d.ShowingDate.Date == DateTime.Parse(date))
                    .Include(m => m.Movie.Genre)
                    .ToListAsync();
            }
            else
            {
                seances = await  _context.Seances.Where(d => d.ShowingDate.Date == DateTime.Today.Date)
                    .Include(m => m.Movie.Genre)
                    .ToListAsync();
            }

            return View(seances);
        }
    }
}