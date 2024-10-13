using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocVoiture.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }
        [Required(ErrorMessage = "le nom de client est requis")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Prenom de client est requis")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Telephone de client est requis")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "L'identifiant client est requis")]
        [RegularExpression(@"^[A-Za-z0-9]{6,}$", ErrorMessage = "Format d'identifiant client invalide")]
        public string CIN { get; set; }

        public IList<Location>? Locations { get; set; }  

    }
}
