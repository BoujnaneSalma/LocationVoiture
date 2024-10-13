using LocVoiture.Context;
using LocVoiture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LocVoiture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger,  MyContext context)
        {
            _logger = logger;
            _context = context;

        }
       [Authorize]
        public IActionResult Index()
        {
            ViewBag.TotalVoitures = _context.Voitures.Count();
            ViewBag.TotalLocations = _context.Locations.Count();
            ViewBag.TotalMarques = _context.Marques.Count();
            ViewBag.TotalAssurances = _context.Assurances.Count();
            ViewBag.TotalClients = _context.Clients.Count();

            return View();
            

           
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
