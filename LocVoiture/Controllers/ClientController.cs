using LocVoiture.Context;
using LocVoiture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocVoiture.Controllers
{
    public class ClientController : Controller
    {
        MyContext db;

        public ClientController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Ajouter(Client C)
        {
            if (ModelState.IsValid)
            {
            db.Clients.Add(C);
            db.SaveChanges();
            return View("List");
            }
            return View();
            
        }
        [Authorize]
        public IActionResult List()
        {
           
            var Client = db.Clients.Include(C => C.Locations).Select(C => new { Client = C, totalLocation = C.Locations.Sum(l => l.Prix_jour) }).ToList();
            ViewBag.client = Client;
            return View();

        }
        public IActionResult ListLocation()
        {
            ViewBag.Clients = db.Clients.Where(C => C.Locations.Any(l => l.Retour == false)).Include(C => C.Locations).Select(C => new
            {
                Client = C,
                totalLocation = C.Locations.Sum(l => l.Prix_jour),
            }).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Client c = db.Clients.Where(c => c.IdClient == id).FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult Update(int id, Client c)
        {
            c.IdClient = id;
            db.Clients.Update(c);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            Client client = db.Clients.Where(
                c => c.IdClient == id).Include(c =>c.Locations).FirstOrDefault();
           if(client.Locations.Count() == 0)
            {
            db.Clients.Remove(client);
            db.SaveChanges();
            }
            else
            {
                TempData["Error"] = "le client a des locations";
            }
            
            return RedirectToAction("List");
        }



    }
}
