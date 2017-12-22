﻿using GigHub.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g=>g.Genre)
                .Where(g => g.DateTime > DateTime.Now).ToList();

            var viewModel = new GigsViewModel()
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Upcoming Gigs"
            };

            return View("Gigs", viewModel);
        }
    }
}