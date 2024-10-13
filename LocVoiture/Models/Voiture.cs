using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocVoiture.Models
{
    public class Voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVoiture { get; set; }

        [Required(ErrorMessage = "La plaque d'immatriculation est requise.")]
      // [StringLength(6, MinimumLength = 2, ErrorMessage = "La plaque d'immatriculation doit comporter entre 6 et 10 caractères.")]
        public string? Matricule { get; set; }

        [Required(ErrorMessage = "Le nombre de portes est requis.")]
        [Range(1, 5, ErrorMessage = "Le nombre de portes doit être compris entre 1 et 5.")]
        
        public int Nbr_portes { get; set; }

        [Required(ErrorMessage = "Le nombre de Places est requis.")]
        [Range(1, 5, ErrorMessage = "Le nombre de Places doit être compris entre 1 et 5.")]
        public int Nbr_places { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une image au format .jpg, .jpeg ou .png.")]
         [RegularExpression(@"^([a-zA-Z0-9\s_-]+\.(jpg|jpeg|png))$", ErrorMessage = "Format d'image non valide. Veuillez sélectionner un fichier .jpg, .jpeg ou .png.")]
       
        public string? Photo_1 { get; set; }
        [Required(ErrorMessage = "Veuillez sélectionner une couleur.")]
        public string Couleur { get; set; }

        public int? MarqueId { get; set; }
        public Marque? Marque { get; set; }

        public IList<Assurance>? Assurances { get; set; }

        public IList<Location>? Locations { get; set; }
        


    }
}
