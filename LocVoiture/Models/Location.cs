using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocVoiture.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocation { get; set; }
        [Required(ErrorMessage = "Date debut est requis")]
        public DateTime Date_debut { get; set; }
        [Required(ErrorMessage = "Date fin est requis")]
        public DateTime Date_fin { get; set; }
        public bool Retour { get; set; }
        [Required(ErrorMessage = "Le prix est requis")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
        public int Prix_jour { get; set; }

        public int? VoitureId { get; set; }
        public Voiture? Voiture { get; set; }

        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        

    }
}
