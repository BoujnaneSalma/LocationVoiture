using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using LocVoiture.Context;
using LocVoiture.Models;
using LocVoiture.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;



//using Microsoft.Reporting.WebForms;

namespace LocVoiture.Controllers
{
    public class VoitureController : Controller
    {
        MyContext db;
        IWebHostEnvironment _webHostEnvironment;



        public VoitureController(MyContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            _webHostEnvironment = webHostEnvironment;
        }


        //list des voitures
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.voituresSort = db.Voitures.Where(v => v.Locations.Any(v => v.Retour == false)).Include(v => v.Marque).Include(v => v.Locations).Include(v => v.Assurances).Select(v => new
            {
                Voiture = v,
                totalLocation = v.Locations.Sum(l => l.Prix_jour),
                totalAss = v.Assurances.Sum(A => A.Prix)

            }).ToList();

            ViewBag.voitures = db.Voitures.Where(v => !v.Locations.Any(v => v.Retour == false)).Include(v => v.Marque).Include(v => v.Locations).Include(v => v.Assurances).Select(v => new
            {
                Voiture = v,
                totalLocation = v.Locations.Sum(l => l.Prix_jour),
                totalAss = v.Assurances.Sum(A => A.Prix)

            }).ToList();

            return View();
        }

        //ajouter voiture
        [HttpGet]
        public IActionResult Add()
        {

            List<Marque> marques = db.Marques.ToList();
            ViewBag.marque = marques;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Voiture v, IFormFile MyImage)
        {
            List<Marque> marques = db.Marques.ToList();
            ViewBag.marque = marques;

            var imageUploader = new uplead();
            var uploadedFileName = await imageUploader.UploadImageAsync(MyImage, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img"));
            v.Photo_1 = uploadedFileName;

            db.Voitures.Add(v);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        //recuperer les données 
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Marque> marques = db.Marques.ToList();
            ViewBag.marque = marques;

            Voiture v = db.Voitures.Where(v => v.IdVoiture == id).FirstOrDefault();
            return View(v);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Voiture v, IFormFile MyImage)
        {
            if (MyImage != null)
            {
                var randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(MyImage.FileName);
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string filePath = Path.Combine(uploadsFolder, randomFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await MyImage.CopyToAsync(fileStream);
                }
                v.Photo_1 = randomFileName;
            }
            List<Marque> marques = db.Marques.ToList();
            ViewBag.marque = marques;

            db.Voitures.Update(v);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Voiture voiture = db.Voitures.Where(
                   v => v.IdVoiture == id).Include(v => v.Marque).Include(v => v.Locations).Include(v => v.Assurances).FirstOrDefault();
            if (voiture.Locations.Count() == 0)
            {
                db.Voitures.Remove(voiture);
                db.SaveChanges();
            }
            else
            {
                TempData["Error"] = "la voiture a des locations";
            }


            return RedirectToAction("Index");
        }
       
        public IActionResult ListAssurance()
        {
            ViewBag.voitureNAss = db.Voitures.Where(v => !v.Assurances.Any(a => a.Date_fin > DateTime.Now)).Include(v => v.Marque).Include(v => v.Locations).Include(v => v.Assurances).Select(v => new
            {
                Voiture = v,
                totalLocation = v.Locations.Sum(l => l.Prix_jour),
                totalAss = v.Assurances.Sum(A => A.Prix)

            }).ToList();

            return View();
        }
        public IActionResult Print()
        {
            
           string path = Path.Combine(_webHostEnvironment.ContentRootPath, "report", "Report1.rdlc"); //récupère le chemin racine du répertoire de contenu
                LocalReport report = new LocalReport(path); //pour générer des rapports
                                                          
                List<Voiture> v = db.Voitures.AsNoTracking().ToList(); //améliorer les performances en évitant le suivi inutile des entités 

            // Ajout du chemin de l'image pour chaque voiture
            foreach (var voiture in v)
            {
                string imagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot/img", $"{voiture.Photo_1}");

                // Vérifiez si le fichier image existe
                using (Image image = Image.FromFile(imagePath))
                {
                    // Convertit l'image en tableau d'octets
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, ImageFormat.Jpeg);
                        byte[] imageData = memoryStream.ToArray();

                        // Convertir le tableau d'octets en chaîne Base64
                        string base64Image = Convert.ToBase64String(imageData);
                        // Stocke les données de l'image dans l'objet Voiture
                        voiture.Photo_1 = base64Image;
                    }
                }

            }

            report.AddDataSource("DataSet1", v);
          
            ReportResult res = report.Execute(RenderType.Pdf);
                return File(res.MainStream, "application/pdf", "ListeDeVoitures.pdf");
            

        }

      
    }



    }
    

