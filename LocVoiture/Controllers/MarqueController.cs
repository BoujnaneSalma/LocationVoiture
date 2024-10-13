using LocVoiture.Context;
using LocVoiture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocVoiture.Controllers
{
    public class MarqueController : Controller
    {
        MyContext db;

        public MarqueController(MyContext db)
        {
            this.db = db;
        }



        //list des marques
        [Authorize]
        public IActionResult Index()
        {
            List<Marque> marques = db.Marques.Include(m => m.Voitures).ToList();  
            return View(marques);
        }
        //ajouter marque
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Marque m)
        {
            db.Marques.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //recuperer les données 
        [HttpGet]
        
        public IActionResult Update(int id)
        {

           Marque m = db.Marques.Where(m => m.IdMarque == id).FirstOrDefault();
            return View(m);
        }

        [HttpPost]
        public IActionResult Update(int id,Marque m)
        {
            m.IdMarque = id;
            db.Marques.Update(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
           Marque marque= db.Marques.Where(m => m.IdMarque == id).Include(m =>m.Voitures).FirstOrDefault();
            if (marque.Voitures.Count() == 0)
            {
                db.Marques.Remove(marque);
                db.SaveChanges();
            }
            else
            {
                TempData["Error"] = "la marque a des Voitures";
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
       
      

    } 

}
