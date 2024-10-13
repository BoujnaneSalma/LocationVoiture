using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocVoiture.Models
{
    public class Marque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMarque { get; set; }
        [Required(ErrorMessage = "le Libelle de Marque est requis")]
        public string Libelle { get; set; }
        public IList<Voiture>? Voitures { get; set;  }
    }
}
