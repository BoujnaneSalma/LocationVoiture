using LocVoiture.Context;
using LocVoiture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocVoiture.Controllers
{
    public class AssuranceController : Controller
    {
        MyContext db;
        public AssuranceController(MyContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            Voiture voiture = db.Voitures.Where(v => v.IdVoiture == id).FirstOrDefault();
            ViewBag.Voiture = voiture;
             Assurance assurance = new Assurance();
            assurance.Date_debut = DateTime.Now;
            return View(assurance);
        }
        [HttpPost]
        public IActionResult Add(Assurance A , int id)
        { 
 
            if(ModelState.IsValid)
            {
                A.AssuranceId = 0;
                A.VoitureId = id;
                if(A.Date_fin > DateTime.Now)
                {
                db.Assurances.Add(A);
                db.SaveChanges();
                return RedirectToAction("Index","Voiture");
                }
                
            }

           

            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
            List<Assurance> assurance = db.Assurances.Include(A => A.Voiture).ToList();
            return View(assurance);
            }
            return View();
            
        }
        public IActionResult Delete(int id)
        {
            db.Assurances.Remove(db.Assurances.Where(A => A.AssuranceId == id).Include(A => A.Voiture).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
