using LocVoiture.Context;
using LocVoiture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocVoiture.Controllers
{
    public class LocationController : Controller
    {
        MyContext db;

        public LocationController(MyContext db)
        {
            this.db = db;
        }
        /*
        [HttpGet]
        public IActionResult Ajouter(int id)
        {
            Voiture voiture = db.Voitures.Where(v => v.IdVoiture == id).FirstOrDefault();
            ViewBag.voiture = voiture;
            List<Client> Clients = db.Clients.ToList();
            ViewBag.client = Clients;
            Location location = new Location();
            location.Date_debut = DateTime.Now;

            return View(location);
        }
        [HttpPost]
        public IActionResult Ajouter(Location L, int id)
        {
            L.IdLocation = 0;
            L.VoitureId = id;
            L.Retour = false;

            if (ModelState.IsValid)
            {
            db.Locations.Add(L);
            db.SaveChanges();
            return RedirectToAction("List");
           
            }
            
           return View();

        }
        */
        [HttpGet]
        public IActionResult AjouterX(int id)
        {
            Voiture voiture = db.Voitures.Where(v => v.IdVoiture == id).FirstOrDefault();
            ViewBag.voiture = voiture;
            Location location = new Location();
            location.Date_debut = DateTime.Now;

            return View(location);
        }
        [HttpPost]
        public IActionResult AjouterX(Location L, int id)
        {

            L.IdLocation = 0;
            L.VoitureId = id;
            L.Retour = false;

            if (ModelState.IsValid)
            {
                db.Locations.Add(L);
                db.SaveChanges();
                return RedirectToAction("Index","Voiture");

            }

            Voiture voiture = db.Voitures.Where(v => v.IdVoiture == id).FirstOrDefault();
            ViewBag.voiture = voiture;
            return View();




        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Retour(int id)
        {
            // Trouver la location avec l'ID spécifié
            var location = db.Locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            // Modifier la valeur de Retour à true
            location.Retour = true;

            // Mettre à jour la location dans la base de données
            db.Locations.Update(location);
            await db.SaveChangesAsync();

            // Rediriger vers la liste des locations
            return RedirectToAction("Index", "Voiture");
        }
        // Méthode AJAX pour récupérer les informations d'un client

        [HttpGet]
           public IActionResult GetClientInfo(int clientId)
           {
               var client = db.Clients.Find(clientId);
               if (client == null)
               {
                   return NotFound();
               }

               return Json(new { telephone = client.Tel, cin = client.CIN });
           }

        [HttpGet]
        public IActionResult GetVoitureInfo(int voitureId)
        {
            var Voiture = db.Voitures.Find(voitureId);
            if (Voiture == null)
            {
                return NotFound();
            }

            return Json(new { Photo = Voiture.Photo_1 });
        }
        /*
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            if (ModelState.IsValid)
            {
               
                    List<Location> location = db.Locations.Include(L => L.Voiture).Include(L => L.Client).ToList();
                    return View(location);
                
            }
            return View();
          
        }
    
        /*
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return PartialView("_Details", client);
        }
        */
        //recuperer les données 
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Voiture> voitures = db.Voitures.ToList();
            ViewBag.voiture = voitures;

            List<Client> Clients = db.Clients.ToList();
            ViewBag.client = Clients;

            Location L = db.Locations.Where(L => L.IdLocation == id).FirstOrDefault();
            return View(L);
        }

        [HttpPost]
        public IActionResult Update(int id,Location L)
        {
            L.IdLocation = id;
            List<Voiture> voitures = db.Voitures.ToList();
            ViewBag.voiture = voitures;

            List<Client> Clients = db.Clients.ToList();
            ViewBag.client = Clients;

            db.Locations.Update(L);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            db.Locations.Remove(db.Locations.Where(
                 v => v.IdLocation == id).Include(L => L.Voiture).Include(L => L.Client).FirstOrDefault());

            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}
